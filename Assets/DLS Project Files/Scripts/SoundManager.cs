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
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }



    }
}
