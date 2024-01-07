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

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        if (Instance == null)  // 단 하나만 존재하게끔
        {
            Instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
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