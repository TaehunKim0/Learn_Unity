using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [HideInInspector]
    public float MoveSpeed = 2f;

    public GameObject ExplodeFX;

    [SerializeField]
    private float LifeTime = 3f;


    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0));
    }

    private void OnDestroy()
    {
        Instantiate(ExplodeFX, transform.position, Quaternion.identity);
    }
}