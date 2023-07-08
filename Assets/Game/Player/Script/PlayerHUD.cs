using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHUD : MonoBehaviour
{
    public UIDocument HUD;

    [HideInInspector]
    public VisualElement[] Hearts;

    private PlayerStatus _playerStatus;

    void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        Hearts = new VisualElement[_playerStatus.Health];

        GroupBox groupBox = HUD.rootVisualElement.Q<GroupBox>("HeartBox");

        for (int i = 0; i < _playerStatus.Health; i++)
        {
            Hearts[i] = new VisualElement();
            Hearts[i].AddToClassList("heart");
            groupBox.Add(Hearts[i]);
        }
    }

    void Update()
    {
    }
}
