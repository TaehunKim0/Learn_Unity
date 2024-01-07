using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeaponItem : MonoBehaviour, IItem
{
    public void OnGetItem(CharacterManager characterManager)
    {
        if (characterManager == null && characterManager.Player)
        {
            PlayerCharacter playerCharacter = characterManager.Player.GetComponent<PlayerCharacter>();

            int currentLevel = playerCharacter.WeaponLevel;
            int maxLevel = playerCharacter.MaxWeaponLevel;

            playerCharacter.WeaponLevel = Mathf.Clamp(currentLevel + 1, 0, maxLevel);
        }
    }
}
