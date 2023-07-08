using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _mainMenuUI;

    void Start()
    {
        _mainMenuUI = GetComponent<UIDocument>();
        Button gameStartButton = _mainMenuUI.rootVisualElement.Q<Button>("GameStart");
        Button gameEndButton = _mainMenuUI.rootVisualElement.Q<Button>("GameEnd");

        gameStartButton.clicked += GameStartButtonClick;
        gameEndButton.clicked += GameStartEndClick;
    }

    void GameStartButtonClick()
    {
        SceneManager.LoadScene("Stage");
    }

    void GameStartEndClick()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
