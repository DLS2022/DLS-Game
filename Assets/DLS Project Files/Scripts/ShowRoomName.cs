using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class ShowRoomName : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the text for game objects name to be displayed")]
    TextMeshProUGUI roomText;

    private string FirstWord = "_ _ _ _ _";
    private string SecondWord = "_ _ _ _ _";
    private string ThirdWord = "_ _ _ _ _";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        roomText.SetText(FirstWord + "    " + SecondWord + "    " + ThirdWord);

        
    }

    [YarnCommand("setfoundwords")]
    private void SetFoundWords(GameObject gameobj, string foundword, int whichword)
    {
        if(whichword == 1)
        {
            FirstWord = foundword;
        }
        else if(whichword == 2)
        {
            SecondWord = foundword;
        }
        else if(whichword == 3)
        {
            ThirdWord = foundword;
        }
    }

}
