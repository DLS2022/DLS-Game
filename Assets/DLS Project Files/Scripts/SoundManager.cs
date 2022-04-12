using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource sound;
    public AudioSource chadAudio;

    public AudioSource didiAudio;

    public AudioSource slugAudio;


    public AudioClip doorOpen;
    public AudioClip doorOpen2;
    public AudioClip doorRattle;
    public AudioClip walkingSFX;
    public AudioClip interactionSFX;
    public AudioClip ambientPartySFX;
    public AudioClip basicUI;
    public AudioClip StartGameUI;

    

    private void Awake()
    {   
        // if (instance != null)
        // {
        //     instance = this;
        //     // DontDestroyOnLoad(gameObject);
        // }
        // else 
        // {
           
        //    Destroy(gameObject);

        // }

        // instance = this;
        // DontDestroyOnLoad(instance);

        // if (instance != null && instance != this)
        //     Destroy(this);

        if (instance == null) {
        //First run, set the instance
        instance = this;
        DontDestroyOnLoad(gameObject);
 
    } else if (instance != this) {
        //Instance is not the same as the one we have, destroy old one, and reset to newest one
        Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

        // if (instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // instance = this;
        // DontDestroyOnLoad(gameObject);


    }
}
