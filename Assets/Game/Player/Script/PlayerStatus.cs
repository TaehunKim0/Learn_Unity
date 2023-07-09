using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatus : MonoBehaviour
{
    public int Health;
    private int MaxHealth;

    void Start()
    {
        SoundManager.instance.PlayBGM("Bgm1");
        MaxHealth = Health;
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

            SoundManager.instance.PlaySFX("Hit");

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Health += 1;

            if(Health <= MaxHealth)
            {
                GetComponent<PlayerHUD>().Hearts[Health - 1].style.display = DisplayStyle.Flex;
            }
            else
            {
                Health = MaxHealth;
            }

            SoundManager.instance.PlaySFX("Hit");

            Destroy(collision.gameObject);
        }
    }
}