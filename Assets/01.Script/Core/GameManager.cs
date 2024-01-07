using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField]
    private CharacterManager _characterManager;
    
    [SerializeField]
    private MapManager _mapManager;

    [SerializeField]
    private EnemySpawnManager _enemySpawnManager;

    public SoundManager SoundManager;

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (Instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            Instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
        }
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        _characterManager.Init(this);
        _mapManager.Init(this);
        _enemySpawnManager.Init(this);

        SoundManager.PlayBGM("BGM");
    }
}