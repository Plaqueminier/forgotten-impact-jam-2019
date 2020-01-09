using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
    public DialogueTrigger dialogue;
    public DialogueManager manager;
    public deathMenu menu;
    public ParticleSystem winParticles;
    public Transform Player;
    public CharacterScript charScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.isUse == 1 && manager.animator.GetBool("IsOpen") == false) {
            Debug.Log("Menu");
            winParticles.transform.position = Player.position;
            winParticles.Play();
            menu.TogglePauseMenu();
            dialogue.isUse = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            charScript.isPaused = true;
    }
}
