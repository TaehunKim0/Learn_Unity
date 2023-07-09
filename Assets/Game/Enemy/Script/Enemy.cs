using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 3f;
    public float AttackDamage = 1f;
    public AudioClip HitSound;

    void Start()
    {
        Health = 3f;
        AttackDamage = 1f;
    }

    void Update()
    {
        if(Health <= 0)
        {
            AddScore();
            Destroy(gameObject);
        }
    }

    private void AddScore()
    {
        ScoreManager.Score += 100;
        GameObject player = GameObject.Find("Player");
        if (player is not null)
        {
            player.GetComponent<PlayerHUD>().UpdateScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1f;

            SoundManager.instance.PlaySFX("Hit");

            Destroy(collision.gameObject);
        }
    }
}