using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelItem : MonoBehaviour, IItem
{
    public void OnGetItem(CharacterManager characterManager)
    {
        PlayerFuelSystem system = characterManager.Player.GetComponent<PlayerFuelSystem>();
        if (system != null)
        {
            system.Fuel = system.MaxFuel;
        }
    }
}
