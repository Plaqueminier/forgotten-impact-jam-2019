using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneChangerScript changeScene;
    public string SceneName;
    public PauseMenuScript pauseMenu;
    bool isOnTheDoor = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        isOnTheDoor = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnTheDoor = false;
    }

    void Update()
    {
        if (pauseMenu.isOpen == false && Input.GetKeyDown(KeyCode.Return) && isOnTheDoor == true) {
            changeScene.SceneName = SceneName;
            changeScene.FadeAndLoadScene();
        }
    }
}
