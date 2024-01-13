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
        if (collision.gameObject.CompareTag("Enemy") && !GameManager.Instance.GetPlayerCharacter().Invincibility)
        {
            Health -= 1;
            StartCoroutine(HitFlick());

            GameManager.Instance.SoundManager.PlaySFX("Hit");

            Debug.Log("플레이어 맞음");

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