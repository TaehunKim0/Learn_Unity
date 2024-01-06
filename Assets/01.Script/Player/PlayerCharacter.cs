using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    #region Movement
    private Vector2 _moveInput;
    public float MoveSpeed;
    #endregion

    #region Skills
    private Dictionary<EnumTypes.PlayerSkill, BaseSkill> _skills;
    [SerializeField] private GameObject[] _skillPrefabs;
    #endregion

    public override void Init(CharacterManager characterManager)
    {
        base.Init(characterManager);
        InitializeSkills();
    }
    private void Update()
    {
        UpdateMovement();
        UpdateSkillInput();
    }

    private void UpdateMovement()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(_moveInput.x, _moveInput.y, 0f) * (MoveSpeed * Time.deltaTime));
    }

    private void UpdateSkillInput()
    {
        if (Input.GetKey(KeyCode.Z)) ActivateSkill(EnumTypes.PlayerSkill.Primary);
        if (Input.GetKey(KeyCode.X)) ActivateSkill(EnumTypes.PlayerSkill.Repair);
        if (Input.GetKey(KeyCode.C)) ActivateSkill(EnumTypes.PlayerSkill.Bomb);
    }

    private void InitializeSkills()
    {
        _skills = new Dictionary<EnumTypes.PlayerSkill, BaseSkill>();

        for (int i = 0; i < _skillPrefabs.Length; i++)
        {
            AddSkill((EnumTypes.PlayerSkill)i, _skillPrefabs[i]);
        }
    }

    private void AddSkill(EnumTypes.PlayerSkill skillType, GameObject prefab)
    {
        GameObject skillObject = Instantiate(prefab, transform.position, Quaternion.identity);
        skillObject.transform.parent = this.transform;

        if (skillObject != null)
        {
            BaseSkill skillComponent = skillObject.GetComponent<BaseSkill>();
            if (skillComponent != null)
            {
                skillComponent.Init(_characterManager);
                _skills.Add(skillType, skillComponent);
            }
            else
            {
                Debug.LogError("Skill component not found on the prefab: " + skillType.ToString());
                Destroy(skillObject);
            }
        }
        else
        {
            Debug.LogError("Failed to instantiate skill prefab: " + skillType.ToString());
        }
    }

    private void ActivateSkill(EnumTypes.PlayerSkill skillType)
    {
        if (_skills.ContainsKey(skillType))
        {
            if (_skills[skillType].IsAvailable())
                _skills[skillType].Activate();
        }
        else
        {
            Debug.LogWarning("Skill not found: " + skillType.ToString());
        }
    }
}
