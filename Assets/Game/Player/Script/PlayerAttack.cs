using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttack : MonoBehaviour
{
    public float AttackCoolDown;
    public float ProjectileMoveSpeed;
    public GameObject Projectile;
    public Transform ProjectileSpawnTransform;

    private bool _isCoolDown = false;
    private float _time = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (null == Projectile)
        {
            Console.WriteLine("Projectile is null");
            return;
        }

        if(_isCoolDown)
        {
            _time += Time.deltaTime;

            if(_time > AttackCoolDown )
            {
                _time = 0f;
                _isCoolDown = false;
            }
        }

        if (Input.GetKey(KeyCode.Space) && !_isCoolDown)
        {
            GameObject projectile = Instantiate(Projectile, ProjectileSpawnTransform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileMovement>().MoveSpeed = ProjectileMoveSpeed;

            _isCoolDown = true;

            SoundManager.instance.PlaySFX("PlayerAttack");
        }
    }
}
