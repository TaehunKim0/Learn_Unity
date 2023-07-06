using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBackgroundScroll : MonoBehaviour
{
    public float ScrollSpeed;

    void Start()
    {
    }

    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(ScrollSpeed * Time.deltaTime, 0); 
    }
}