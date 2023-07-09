using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 3f;
    public float AttackDamage = 1f;
    public GameObject HealthUpItem;

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

            if (Random.Range(1, 10) == 5)
                Instantiate(HealthUpItem, transform.position, Quaternion.identity);
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

    private void OnDestroy()
    {
        if(Random.Range(1, 10) == 5)
            ItemManager.instance.SpawnItem(ItemName.HealthUp, transform.position);
    }
}