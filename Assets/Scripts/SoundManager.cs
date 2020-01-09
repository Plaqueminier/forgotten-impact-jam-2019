using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip run, jump, slash, landing, stop, slash_hit;
    static public AudioClip run_s, jump_s, slash_s, landing_s, stop_s, slash_hit_s;
    static AudioSource audioSrc;

    void Start()
    {
        run_s = run ;
        jump_s = jump;
        slash_s = slash;
        landing_s = landing;
        stop_s = stop;
        slash_hit_s = slash_hit;

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void playSound(string clip)
    {
        switch (clip) {
            case "run":
                audioSrc.PlayOneShot(run_s);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump_s);
                break;
            case "slash":
                audioSrc.PlayOneShot(slash_s);
                break;
            case "landing":
                audioSrc.PlayOneShot(landing_s);
                break;
            case "stop":
                audioSrc.PlayOneShot(stop_s);
                break;
            case "slash_hit":
                audioSrc.PlayOneShot(slash_hit_s);
                break;
        }
    }
}
