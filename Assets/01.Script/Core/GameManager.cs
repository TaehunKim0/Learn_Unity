using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CharacterManager characterManager;
    
    [SerializeField]
    private MapManager mapManager;

    void Start()
    {
        characterManager.Init(this);
        mapManager.Init(this);
    }

}