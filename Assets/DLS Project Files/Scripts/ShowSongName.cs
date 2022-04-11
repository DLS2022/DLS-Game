using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class ShowSongName : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the text for game objects name to be displayed")]
    TextMeshProUGUI roomText;

    [SerializeField]
    [Tooltip("Chad Audio Source")]
    AudioSource chadAudio;

    [SerializeField]
    [Tooltip("Didi Audio Source")]
    AudioSource didiAudio;

    [SerializeField]
    [Tooltip("Slug Audio Source")]
    AudioSource slugAudio;

    private string FirstWord = "_ _ _ _ _ _ _ _ _";
    private string SecondWord = "_ _ _ _ _ _ _ _ _";
    private string ThirdWord = "_ _ _";
    //B e l o n g i n g              9 Letters
    //S o m e w h e r e              9 Letters
    //N e w                          3 Letters

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        roomText.SetText(FirstWord + "    " + SecondWord + "    " + ThirdWord);
        /*
        BELONGING SOMEWHERE NEW

        BELONGING: DIDI
        SOMEWHERE: JOCK
        NEW: PUN
        */
        
    }

    [YarnCommand("setfoundwords")]
    private void SetFoundWords(GameObject gameobj, string foundword, int whichword)
    {
        if(whichword == 1)
        {
            FirstWord = foundword;
            chadAudio.mute = false;
        }
        else if(whichword == 2)
        {
            SecondWord = foundword;
            didiAudio.mute = false;
        }
        else if(whichword == 3)
        {
            ThirdWord = foundword;
            slugAudio.mute = false;
        }

        GlobalVariables.AllFoundWords[whichword-1] = true;
        Debug.Log("Word " + whichword + " " + GlobalVariables.AllFoundWords[whichword-1]);
    }

}
