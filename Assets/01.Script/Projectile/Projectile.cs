using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public float MoveSpeed = 2f;

    public GameObject ExplodeFX;

    [SerializeField]
    private float _lifeTime = 3f;
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, MoveSpeed * Time.deltaTime, 0));
    }

    private void OnDestroy()
    {
        //Instantiate(ExplodeFX, transform.position, Quaternion.identity);
    }
}