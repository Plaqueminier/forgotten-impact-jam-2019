using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.Tween;

public class PauseMenuScript : MonoBehaviour
{
    public bool isOpen = false;

    public GameObject PauseMenu;
    public RectTransform ResumeButton;
    public RectTransform QuitButton;
    public RectTransform MainMenuButton;
    public RectTransform SettingsButton;
    public Image Screen;

    public SceneChangerScript changeScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
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

    private void OpenPauseMenu()
    {
        Color color = Screen.color;
        Vector2 ResumePos = ResumeButton.position;
        Vector2 MainMenuPos = MainMenuButton.position;
        Vector2 SettingsPos = SettingsButton.position;
        Vector2 QuitPos = QuitButton.position;
        ResumeButton.anchorMin = new Vector2(0.5f, 0.5f);
        ResumeButton.anchorMax = new Vector2(0.5f, 0.5f);
        ResumeButton.position = ResumePos;
        MainMenuButton.anchorMin = new Vector2(0.5f, 0.5f);
        MainMenuButton.anchorMax = new Vector2(0.5f, 0.5f);
        MainMenuButton.position = MainMenuPos;
        SettingsButton.anchorMin = new Vector2(0.5f, 0.5f);
        SettingsButton.anchorMax = new Vector2(0.5f, 0.5f);
        SettingsButton.position = SettingsPos;
        QuitButton.anchorMin = new Vector2(0.5f, 0.5f);
        QuitButton.anchorMax = new Vector2(0.5f, 0.5f);
        QuitButton.position = QuitPos;
        TweenFactory.Tween("Screen", color.a, 0.4f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            color.a = t.CurrentValue;
            Screen.color = color;
        }, null);
        TweenFactory.Tween("Resume", ResumeButton.anchoredPosition.y, 225f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            ResumeButton.anchoredPosition = new Vector2(ResumeButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("MainMenu", MainMenuButton.anchoredPosition.y, 100f, 0.45f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            MainMenuButton.anchoredPosition = new Vector2(MainMenuButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("Settings", SettingsButton.anchoredPosition.y, -100f, 0.45f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            SettingsButton.anchoredPosition = new Vector2(SettingsButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("Quit", QuitButton.anchoredPosition.y, -225f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            QuitButton.anchoredPosition = new Vector2(QuitButton.anchoredPosition.x, t.CurrentValue);
        }, null);
    }

    private void ClosePauseMenu()
    {
        Color color = Screen.color;
        Vector2 ResumePos = ResumeButton.position;
        Vector2 MainMenuPos = MainMenuButton.position;
        Vector2 SettingsPos = SettingsButton.position;
        Vector2 QuitPos = QuitButton.position;
        ResumeButton.anchorMin = new Vector2(0.5f, 1f);
        ResumeButton.anchorMax = new Vector2(0.5f, 1f);
        ResumeButton.position = ResumePos;
        MainMenuButton.anchorMin = new Vector2(0.5f, 1f);
        MainMenuButton.anchorMax = new Vector2(0.5f, 1f);
        MainMenuButton.position = MainMenuPos;
        SettingsButton.anchorMin = new Vector2(0.5f, 0f);
        SettingsButton.anchorMax = new Vector2(0.5f, 0f);
        SettingsButton.position = SettingsPos;
        QuitButton.anchorMin = new Vector2(0.5f, 0f);
        QuitButton.anchorMax = new Vector2(0.5f, 0f);
        QuitButton.position = QuitPos;
        TweenFactory.Tween("Screen", color.a, 0f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            color.a = t.CurrentValue;
            Screen.color = color;
        }, null);
        TweenFactory.Tween("Resume", ResumeButton.anchoredPosition.y, 200f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            ResumeButton.anchoredPosition = new Vector2(ResumeButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("MainMenu", MainMenuButton.anchoredPosition.y, 200f, 0.45f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            MainMenuButton.anchoredPosition = new Vector2(MainMenuButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("Settings", SettingsButton.anchoredPosition.y, -200f, 0.45f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            SettingsButton.anchoredPosition = new Vector2(SettingsButton.anchoredPosition.x, t.CurrentValue);
        }, null);
        TweenFactory.Tween("Quit", QuitButton.anchoredPosition.y, -200f, 0.5f, TweenScaleFunctions.QuadraticEaseOut, (t) =>
        {
            QuitButton.anchoredPosition = new Vector2(QuitButton.anchoredPosition.x, t.CurrentValue);
        }, null);
    }

    public void QuitGame()
    {
        PauseMenu.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
        Application.Quit();
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
