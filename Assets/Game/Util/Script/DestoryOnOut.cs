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
            Destroy(transform.parent.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
