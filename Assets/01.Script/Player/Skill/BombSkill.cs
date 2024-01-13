using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : BaseSkill
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

        // ��� Enemy ã��
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemies)
        {
            if (obj != null)
            {
                Enemy enemy = obj.GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.Dead();
                }
            }
        }

    }
}