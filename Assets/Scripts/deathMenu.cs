using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.Tween;

public class deathMenu : MonoBehaviour
{
    public bool isOpen = false;

    public GameObject PauseMenu;
    public RectTransform NextlevelButton;
    public RectTransform MainMenuButton;
    public Image Screen;

    public SceneChangerScript changeScene;

    void Update()
    {
    }

    public void TogglePauseMenu()
    {
        if (!isOpen) {
            PauseMenu.SetActive(true);
            isOpen = true;
            Time.timeScale = 0f;
        }
        else {
            PauseMenu.SetActive(false);
            isOpen = false;
            Time.timeScale = 1f;
        }
    }

    public void NextLvl()
    {
        PauseMenu.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
        changeScene.SceneName = "LevelManager";
        changeScene.FadeAndLoadScene();
    }

    public void BackToMainMenu()
    {
        PauseMenu.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
        changeScene.SceneName = "Main Menu";
        changeScene.FadeAndLoadScene();
    }
}
