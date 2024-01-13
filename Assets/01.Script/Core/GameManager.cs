using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public CharacterManager CharacterManager;
    public MapManager MapManager;
    public EnemySpawnManager EnemySpawnManager;
    public SoundManager SoundManager;

    public Canvas StageClearResultCanvas;
    public TMP_Text CurrentScoreText;
    public TMP_Text ElapsedTimeText;

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        if (Instance == null)  // 단 하나만 존재하게끔
        {
            Instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
        }
        else
            Destroy(this.gameObject);
    }

    public PlayerCharacter GetPlayerCharacter() { return CharacterManager.Player.GetComponent<PlayerCharacter>(); }

    void Start()
    {
        if(CharacterManager == null) { return; }
        CharacterManager.Init(this);
        MapManager.Init(this);
        EnemySpawnManager.Init(this);
        SoundManager.PlayBGM("BGM");

    }

    public void EnemyDies()
    {
        AddScore(10);
    }

    public void StageClear()
    {
        GameInstance.instance.Score += 500;

        float gameStartTime = GameInstance.instance.GameStartTime;
        int score = GameInstance.instance.Score;

        // 걸린 시간
        int elapsedTime = Mathf.FloorToInt(Time.time - gameStartTime);

        // 스테이지 클리어 결과창 : 점수, 시간
        StageClearResultCanvas.gameObject.SetActive(true);
        CurrentScoreText.text = "CurrentScore : " + score;
        ElapsedTimeText.text = "ElapsedTime : " + elapsedTime;

        // 5초 뒤에 다음 스테이지
        StartCoroutine(NextStageAfterDelay(5f));
    }

    IEnumerator NextStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        switch(GameInstance.instance.CurrentStageLevel)
        {
            case 1:
                SceneManager.LoadScene("Stage2");
                GameInstance.instance.CurrentStageLevel = 2;
                break;

            case 2:
                SceneManager.LoadScene("Result");
                break;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void AddScore(int score)
    {
        GameInstance.instance.Score += score;
    }
}