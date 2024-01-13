using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSkill : BaseSkill
{
    void Start()
    {
    }

    void Update()
    {
    }

    public override void Activate()
    {
        base.Activate();

        PlayerHPSystem system = _characterManager.Player.GetComponent<PlayerHPSystem>();
        if (system != null)
        {
            system.Health += 1;

            if(system.Health >= system.MaxHealth)
            {
                system.Health = system.MaxHealth;
            }
        }
    }
}