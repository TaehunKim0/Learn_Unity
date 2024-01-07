using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityItem : MonoBehaviour, IItem
{
    public void OnGetItem(CharacterManager characterManager)
    {
        characterManager.Player.GetComponent<PlayerCharacter>().Invincibility = true;
    }
}
