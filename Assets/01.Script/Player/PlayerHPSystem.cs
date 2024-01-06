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
            // TODO : Event 처리?
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator HitFlick()
    {
        int flickCount = 0; // 깜박인 횟수를 기록하는 변수

        while (flickCount < 5) // 5번 깜박일 때까지 반복
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f); // 스프라이트를 투명도 0.5로 설정

            yield return new WaitForSeconds(0.1f); // 0.1초 대기

            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1); // 스프라이트를 원래 투명도로 설정

            yield return new WaitForSeconds(0.1f); // 0.1초 대기

            flickCount++; // 깜박인 횟수 증가
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