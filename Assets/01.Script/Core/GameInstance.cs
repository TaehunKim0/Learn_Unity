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
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(instance);
        }

        GameStartTime = Time.time;
    }
}