using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [HideInInspector]
    public float MoveSpeed = 0f;

    [SerializeField]
    private float LifeTime = 3f;

    public GameObject ExplodeFX;

    private Vector3 Direction;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position += Direction * MoveSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Instantiate(ExplodeFX, transform.position, Quaternion.identity);
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
}
