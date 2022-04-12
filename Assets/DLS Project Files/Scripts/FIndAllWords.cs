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

        credits.GetComponent<RawImage>().CrossFadeAlpha(0, 0f, true);  
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

        if(Input.GetKeyDown(KeyCode.T))
        {
            GlobalVariables.AllFoundWords[0] = true;
            GlobalVariables.AllFoundWords[1] = true;
            GlobalVariables.AllFoundWords[2] = true;
        }

    }

    IEnumerator StartEnding()
    {
        IsCoroutineRunning = true;
        interaction.RestrictMovement = true;
        interaction.blackPanel.CrossFadeAlpha(1, 2f, false);
        yield return new WaitForSecondsRealtime(2f);

        interaction.diaRunner.StartDialogue(talktonode);

        // SceneManager.LoadScene(0);
        // interaction.RestrictMovement = false;
        // ResetGame(this.gameObject);
    }

    [YarnCommand("startcredits")]
    IEnumerator StartCredits(GameObject gameobj)
    {
        Debug.Log("startcredits");
        // yield return new WaitForSecondsRealtime(1f);
        credits.gameObject.SetActive(true);
        credits.GetComponent<RawImage>().CrossFadeAlpha(1, 2f, false);
        creditAnimation.Play("RollingCredits");
        yield return new WaitForSecondsRealtime(20f);
        credits.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    // <<resetgame FindAllWords this>>
    [YarnCommand("resetgame")]
    private void ResetGame(GameObject gameobj)
    {
        SceneManager.LoadScene(0);
    }
}
