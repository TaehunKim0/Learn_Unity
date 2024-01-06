using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterManager : BaseManager
{
    public BaseCharacter Player;
    private List<BaseCharacter> _enemys = new List<BaseCharacter>();

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);
        Player.Init(this);
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
    }
}