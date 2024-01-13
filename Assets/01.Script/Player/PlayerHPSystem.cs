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
        if (collision.gameObject.CompareTag("Enemy") && !GameManager.Instance.GetPlayerCharacter().Invincibility)
        {
            Health -= 1;
            StartCoroutine(HitFlick());

            GameManager.Instance.SoundManager.PlaySFX("Hit");

            Debug.Log("�÷��̾� ����");

            Destroy(collision.gameObject);

            if (Health <= 0)
            {
                GameManager.Instance.GetPlayerCharacter().DeadProcess();
            }
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

            Debug.Log("4");
            Destroy(collision.gameObject);
        }
    }
}