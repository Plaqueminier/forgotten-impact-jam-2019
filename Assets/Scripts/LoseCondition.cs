using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public bool lost = false;
    public SceneChangerScript changeScene;
    public ParticleSystem loseParticles;
    public Transform Player;
    public CharacterScript charScript;

    void Update()
    {
        if (lost == true)
        {
            Player.gameObject.GetComponent<Animator>().SetBool("Death", true);
            charScript.isPaused = true;
            loseParticles.transform.position = Player.position;
            loseParticles.Play();
            Invoke("ReloadLevel", 0.5f);
        }
    }

    void ReloadLevel()
    {
        changeScene.SceneName = SceneManager.GetActiveScene().name;
        changeScene.FadeAndLoadScene();
    }
}
