using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sound;
    public AudioClip doorOpen;
    public AudioClip walkingSFX;
    public AudioClip interactionSFX;
    public AudioClip ambientPartySFX;
    public AudioClip basicUI;
    public AudioClip StartGameUI;


    private void Awake()
    {
        instance = this;
        sound = Instantiate(sound);
    }
}
