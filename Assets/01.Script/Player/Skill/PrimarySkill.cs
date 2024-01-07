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

        if(_projectile == null)
        {
            Debug.Log("Projectile null");
        }
        if (_characterManager == null)
        {
            Debug.Log("_characterManager null");
        }

        GameObject instance = Instantiate(_projectile, _characterManager.Player.GetComponent<Transform>().position, Quaternion.identity);
        instance.GetComponent<Projectile>().MoveSpeed = ProjectileMoveSpeed;
        instance.GetComponent<Projectile>().SetDirection(Vector3.up);

        GameManager.Instance.SoundManager.PlaySFX("PrimarySkill");
    }
}