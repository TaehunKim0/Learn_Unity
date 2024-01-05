using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
#region Movement
    private Vector2 moveInput;
    public float MoveSpeed;
#endregion

#region Skills
    private Dictionary<EnumTypes.PlayerSkill, BaseSkill> skills;
#endregion
    void Start()
    {
        InitializeSkills();
    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))     moveInput.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow))   moveInput.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow))   moveInput.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow))  moveInput.x = 1f;

        transform.Translate(new Vector3(moveInput.x, moveInput.y , 0f) * MoveSpeed * Time.deltaTime);
    }

    void InitializeSkills()
    {
        skills = new Dictionary<EnumTypes.PlayerSkill, BaseSkill>();
        skills.Add(EnumTypes.PlayerSkill.Primary, new PrimarySkill());
        skills.Add(EnumTypes.PlayerSkill.Repair, new RepairSkill());
        skills.Add(EnumTypes.PlayerSkill.Bomb, new BombSkill());
    }
}