using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    private List<RankingEntry> rankingEntries = new List<RankingEntry>();
    public TextMeshProUGUI[] Rankings = new TextMeshProUGUI[5];
    public TextMeshProUGUI CurrentPlayerScore;

    private void Start()
    {
        SetCurrentScore();
        SortRanking();
        UpdateRankingUI();
    }

    void SetCurrentScore()
    {
        rankingEntries.Clear();

        for (int i = 0; i < 5; i++)
        {
            int currentScore = PlayerPrefs.GetInt(i + "BestScore");
            string currentName = PlayerPrefs.GetString(i + "BestName");
            if (currentName == "")
                currentName = "None";

            rankingEntries.Add(new RankingEntry(currentScore, currentName));
        }

        // ���� �÷��̾��� ������ �̸��� ������ ��ŷ�� ���
        int currentPlayerScore = GameInstance.instance.Score;
        string currentPlayerName = "AAA"; // ���⿡ ���� �÷��̾��� �̸��� �������� �ڵ带 �߰��ؾ� �մϴ�.

        // ���� �÷��̾��� ������ ��ŷ�� ��� �������� Ȯ��
        if (IsScoreEligibleForRanking(currentPlayerScore))
        {
            rankingEntries.Add(new RankingEntry(currentPlayerScore, currentPlayerName));
        }
    }

    bool IsScoreEligibleForRanking(int currentPlayerScore)
    {
        // ��ŷ�� ��� �������� Ȯ�� (��: ���� 5�������� ��� �����ϵ��� ����)
        return rankingEntries.Count < 5 || currentPlayerScore > rankingEntries.Min(entry => entry.Score);
    }

    void SortRanking()
    {
        // ������������ ����
        rankingEntries = rankingEntries.OrderByDescending(entry => entry.Score).ToList();

        // ��ŷ�� 5���� �ʰ��ϸ� ���� ���� ������ ���� �׸��� ����
        if (rankingEntries.Count > 5)
        {
            rankingEntries.RemoveAt(rankingEntries.Count - 1);
        }
    }

    void UpdateRankingUI()
    {
        CurrentPlayerScore.text = $"BBB {GameInstance.instance.Score}";

        for (int i = 0; i < Rankings.Length; i++)
        {
            if (i < rankingEntries.Count)
            {
                Rankings[i].text = $"{i + 1} {rankingEntries[i].Name} : {rankingEntries[i].Score}";
            }
            else
            {
                Rankings[i].text = $"{i + 1} -";
            }
        }

        // PlayerPrefs ������Ʈ
        for (int i = 0; i < rankingEntries.Count; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", rankingEntries[i].Score);
            PlayerPrefs.SetString(i + "BestName", rankingEntries[i].Name);
        }
    }
}

public class RankingEntry
{
    public int Score { get; set; }
    public string Name { get; set; }

    public RankingEntry(int score, string name)
    {
        Score = score;
        Name = name;
    }
}