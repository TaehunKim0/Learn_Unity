using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHPSystem : MonoBehaviour
{
    public int Health;
    private int MaxHealth;

    void Start()
    {
        MaxHealth = Health;
    }

    void Update()
    {
        CheckPlayerDead();
    }

    void CheckPlayerDead()
    {
        if (Health <= 0)
        {
            // TODO : Event ó��?
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator HitFlick()
    {
        int flickCount = 0; // ������ Ƚ���� ����ϴ� ����

        while (flickCount < 5) // 5�� ������ ������ �ݺ�
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f); // ��������Ʈ�� ���� 0.5�� ����

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1); // ��������Ʈ�� ���� ������ ����

            yield return new WaitForSeconds(0.1f); // 0.1�� ���

            flickCount++; // ������ Ƚ�� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 1;
            StartCoroutine(HitFlick());

            //SoundManager.instance.PlaySFX("Hit");

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Health += 1;

            if (Health <= MaxHealth)
            {
            }
            else
            {
                Health = MaxHealth;
            }

            //SoundManager.instance.PlaySFX("TakeItem");

            Destroy(collision.gameObject);
        }
    }
}