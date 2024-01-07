using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairItem : MonoBehaviour ,IItem
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnGetItem(CharacterManager characterManager)
    {
        PlayerHPSystem system = characterManager.Player.GetComponent<PlayerHPSystem>();    
        if (system != null)
        {
            system.Health += 1;
        }

        // æ∆¿Ã≈€ »πµÊ ¿Ã∆Â∆Æ
    }
}
