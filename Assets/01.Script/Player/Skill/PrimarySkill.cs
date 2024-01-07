using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrimarySkill : BaseSkill
{
    public float ProjectileMoveSpeed;
    
    [SerializeField] private GameObject _projectile;

    void Start()
    {
        CooldownTime = 0.2f;
    }

    void Update()
    {

    }

    public override void Activate()
    {
        base.Activate();

        GameObject instance = Instantiate(_projectile, _characterManager.Player.GetComponent<Transform>().position, Quaternion.identity);
        instance.GetComponent<Projectile>().MoveSpeed = ProjectileMoveSpeed;
        instance.GetComponent<Projectile>().SetDirection(Vector3.up);

        GameManager.Instance.SoundManager.PlaySFX("PrimarySkill");
    }
}