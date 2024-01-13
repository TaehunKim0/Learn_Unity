using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    #region Invincibility
    private bool invincibility;
    private Timer invincibilityTimer;
    private const double InvincibilityDurationInSeconds = 3; // ���� ���� �ð� (��)
    public bool Invincibility
    {
        get { return invincibility; }
        set { invincibility = value; }
    }
    #endregion

    #region Weapon
    public int CurrentWeaponLevel = 0;
    public int MaxWeaponLevel = 3;
    #endregion

    public override void Init(CharacterManager characterManager)
    {
        base.Init(characterManager);
        InitializeSkills();
    }

    public void DeadProcess()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
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

        // ī�޶��� ���� �ϴ���(0, 0, 0.0)�̸�, ���� �����(1.0 , 1.0)�̴�.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
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

        CurrentWeaponLevel = GameInstance.instance.CurrentPlayerWeaponLevel;
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
                skillComponent.Init(CharacterManager);
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

    public void SetInvincibility(bool invin)
    {
        if (invin)
        {
            Invincibility = true;

            // �̹� Ÿ�̸Ӱ� ���� ���̸� ����
            if (invincibilityTimer != null)
            {
                invincibilityTimer.Stop();
                invincibilityTimer.Dispose();
            }

            // Ÿ�̸� ���� �� ����
            invincibilityTimer = new Timer(InvincibilityDurationInSeconds * 1000); // �ʸ� �и��ʷ� ��ȯ
            invincibilityTimer.Elapsed += OnInvincibilityTimerElapsed;
            invincibilityTimer.AutoReset = false; // Ÿ�̸� �� ���� ����

            // Ÿ�̸� ����
            invincibilityTimer.Start();
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            Invincibility = false;
            // ������ ������ �� ���⿡ �߰����� �۾��� ������ �� �ֽ��ϴ�.
            GetComponent<SpriteRenderer>().color = Color.white;

            // �̹� Ÿ�̸Ӱ� ���� ���̸� ����
            if (invincibilityTimer != null)
            {
                invincibilityTimer.Stop();
                invincibilityTimer.Dispose();
            }
        }

    }

    private void OnInvincibilityTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Ÿ�̸Ӱ� ����Ǹ� ������ ��Ȱ��ȭ
        Invincibility = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            BaseItem item = collision.gameObject.GetComponent<BaseItem>();
            if (item != null)
            {
                item.OnGetItem(CharacterManager);
                Destroy(collision.gameObject);
            }
        }
    }
}
