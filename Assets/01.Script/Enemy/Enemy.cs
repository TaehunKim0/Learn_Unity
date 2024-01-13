using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : BaseCharacter
{
    public float Health = 3f;
    public float AttackDamage = 1f;
    bool bIsDead = false;

    void Start()
    {
        Health = 3f;
        AttackDamage = 1f;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health -= 1f;
            GameManager.Instance.SoundManager.PlaySFX("EnemyHit");

            if (Health <= 0 && !bIsDead)
            {
                GameManager.Instance.EnemyDies();

                if (Random.Range(0, 1) == 0)
                {
                    int randomInt = Random.Range(0, 4);
                    EnumTypes.ItemName itemName = (EnumTypes.ItemName)randomInt;
                    GameManager.Instance.ItemManager.SpawnItem(itemName, transform.position);
                }

                bIsDead = true;
                Destroy(gameObject);
            }

            StartCoroutine(HitFlick());
            Destroy(collision.gameObject);
        }
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