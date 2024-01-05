using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected CharacterManager characterManager;
    public void Init(CharacterManager inCharacterManager)
    {
        characterManager = inCharacterManager;
    }
}