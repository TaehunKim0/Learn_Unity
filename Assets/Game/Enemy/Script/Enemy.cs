using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 3f;
    public float AttackDamage = 1f;

    void Start()
    {
        Health = 3f;
        AttackDamage = 1f;
    }

    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1f;
            Destroy(collision.gameObject);
        }
    }
}