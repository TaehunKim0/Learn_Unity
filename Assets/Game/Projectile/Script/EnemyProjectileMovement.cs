using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [HideInInspector]
    public float MoveSpeed = 0f;
    public GameObject ExplodeFX;

    [SerializeField]
    private float LifeTime = 3f;
    private Vector3 _direction;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position += _direction * MoveSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Instantiate(ExplodeFX, transform.position, Quaternion.identity);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
