using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image[] HealthImg = new Image[3];
    public Image RepairSkill;
    public Image BombSkill;
    public Slider FuelSlider;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateHealth();
        UpdateSkills();
        UpdateFuel();
    }

    void UpdateHealth()
    {
        int health = GameManager.Instance.GetPlayerCharacter().GetComponent<PlayerHPSystem>().Health;

        for (int i = 0; i < HealthImg.Length; i++)
        {
            if (i < health)
            {
                HealthImg[i].gameObject.SetActive(true);
            }
            else
            {
                HealthImg[i].gameObject.SetActive(false);
            }
        }
    }

    void UpdateSkills()
    {

    }

    void UpdateFuel()
    {
        if (FuelSlider != null)
        {
            FuelSlider.value = GameManager.Instance.GetPlayerCharacter().GetComponent<PlayerFuelSystem>().Fuel / 100;
        }
    }
}
