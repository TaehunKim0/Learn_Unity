using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;
    private Transform _transform;

    public float MoveSpeed;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))      _moveInput.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow))   _moveInput.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow))   _moveInput.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow))  _moveInput.x = 1f;

        _transform.Translate(new Vector3(_moveInput.x, _moveInput.y , 0f) * MoveSpeed * Time.deltaTime);
    }
}