using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterManager : BaseManager
{
    public BaseCharacter Player;
    private List<BaseCharacter> _enemys = new List<BaseCharacter>();

    void Start()
    {
        Player.Init(this);
    }

    void Update()
    {
    }
}