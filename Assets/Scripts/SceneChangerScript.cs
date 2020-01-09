using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{

    public Animator FadeOut;
    public string SceneName;

    public void FadeAndLoadScene()
    {
        FadeOut.SetTrigger("FadeOut");
        Invoke("LoadSceneName", 1f);
    }

    void LoadSceneName()
    {
        SceneManager.LoadScene(SceneName);
    }
}
