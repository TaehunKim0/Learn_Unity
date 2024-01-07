using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFuelSystem : MonoBehaviour
{
    public float Fuel = 100f;
    public float MaxFuel = 100f;
    public float FuelDecreaseSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Fuel -= FuelDecreaseSpeed * Time.deltaTime;

        if(Fuel <= 0f)
        {
            GameManager.Instance.GetPlayerCharacter().DeadProcess();
        }
    }
}
