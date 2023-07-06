using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern1 : MonoBehaviour
{
    public float MoveSpeed;

    void Start()
    {
        GetComponentInChildren<Animator>().Play("Enemy_Pattern1");
    }

    void Update()
    {
        transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0f, 0f);
    }
}