using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    protected GameManager gameManager;
    
    public GameManager GameManager{ get{return gameManager;} }
    public void Init(GameManager inGameManager)
    {
        gameManager = inGameManager;
    }
}