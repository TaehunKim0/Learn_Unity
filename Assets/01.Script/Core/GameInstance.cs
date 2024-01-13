using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    [HideInInspector] public float GameStartTime = 0f;
    [HideInInspector] public int Score = 0;
    [HideInInspector] public int CurrentPlayerWeaponLevel = 0;
    public static GameInstance instance;
    [HideInInspector] public int CurrentStageLevel = 1;

    private void Awake()
    {
        if (instance == null)  // 단 하나만 존재하게끔
        {
            instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(instance);
        }

        GameStartTime = Time.time;
    }
}