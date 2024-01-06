using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CharacterManager _characterManager;
    
    [SerializeField]
    private MapManager _mapManager;

    void Start()
    {
        _characterManager.Init(this);
        _mapManager.Init(this);
    }

}