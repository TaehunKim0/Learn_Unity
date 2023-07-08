using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatus : MonoBehaviour
{
    public int Health;

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayerDead();
    }

    void CheckPlayerDead()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);

            // UI
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 1;

            GetComponent<PlayerHUD>().Hearts[Health].style.display = DisplayStyle.None;

            Destroy(collision.gameObject);
        }
    }
}