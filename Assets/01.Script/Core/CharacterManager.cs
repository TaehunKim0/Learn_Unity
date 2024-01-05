using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterManager : BaseManager
{
    [SerializeField]
    private BaseCharacter player;   
    
    private List<BaseCharacter> enemys = new List<BaseCharacter>();

    void Start()
    {
        player.Init(this);
    }

    void Update()
    {
    }
}