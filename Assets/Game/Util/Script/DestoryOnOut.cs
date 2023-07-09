using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOut : MonoBehaviour
{
    private bool _isSpawn = false;

    private void OnBecameVisible()
    {
        _isSpawn = true;
    }

    void OnBecameInvisible()
    {
        if (_isSpawn is true)
        {
            if (transform.parent is not null)
            {
                Destroy(transform.parent.gameObject);
                return;
            }

            Destroy(transform.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
