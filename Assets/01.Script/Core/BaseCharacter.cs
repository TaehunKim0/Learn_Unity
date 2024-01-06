using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected CharacterManager _characterManager;
    public virtual void Init(CharacterManager characterManager)
    {
        _characterManager = characterManager;
    }
}