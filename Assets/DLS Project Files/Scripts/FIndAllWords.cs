using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FIndAllWords : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Credits Animator")]
    Animator creditAnimation;

    [SerializeField]
    [Tooltip("The Credits Image")]
    GameObject credits;


    Interaction interaction;
    bool IsCoroutineRunning;

    public string talktonode;

    void Awake()
    {
        interaction = FindObjectOfType<Interaction>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if
        (
            GlobalVariables.AllFoundWords[0] == true &&
            GlobalVariables.AllFoundWords[1] == true &&
            GlobalVariables.AllFoundWords[2] == true &&
            !interaction.diaRunner.IsDialogueRunning &&
            !IsCoroutineRunning
        )
        {
            StartCoroutine(StartEnding());
        }


    }

    IEnumerator StartEnding()
    {
        IsCoroutineRunning = true;
        interaction.RestrictMovement = true;
        interaction.blackPanel.CrossFadeAlpha(1, 2f, false);
        yield return new WaitForSecondsRealtime(2f);

        interaction.diaRunner.StartDialogue(talktonode);


        credits.gameObject.SetActive(true);
        credits.GetComponent<RawImage>().CrossFadeAlpha(1, 2f, false);
        creditAnimation.Play("RollingCredits");
        GameManager.Instance.MainMenu();

    }

    [YarnCommand("resetgame")]
    private void ResetGame(GameObject gameobj)
    {
        SceneManager.LoadScene(0);
    }
}
