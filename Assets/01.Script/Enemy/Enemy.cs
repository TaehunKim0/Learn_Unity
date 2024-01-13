using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : BaseCharacter
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
        if (Health <= 0)
        {
            GameManager.Instance.EnemyDies();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1f;
            GameManager.Instance.SoundManager.PlaySFX("EnemyHit");

            StartCoroutine(HitFlick());
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        //if (Random.Range(1, 10) == 5)
            //ItemManager.instance.SpawnItem(ItemName.HealthUp, transform.position);
    }

    IEnumerator HitFlick()
    {
        int flickCount = 0; // ������ Ƚ���� ����ϴ� ����

        while (flickCount < 1) // 1�� ������ ������ �ݺ�
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1); 

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            flickCount++; // ������ Ƚ�� ����
        }
    }
}