using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using StarterAssets;
using UnityEngine.SceneManagement;

public class BathroomDialogueStartup : MonoBehaviour
{

    [Header("Yarn Components")]
    public string talktonode;
    public DialogueRunner diaRunner;

    public GameObject player;
    public FirstPersonController fpcscript;

    Interaction interaction;

    // Start is called before the first frame update
    void Awake()
    {
        if(GlobalVariables.BathroomDialogueValue == 0)
        {
            GlobalVariables.AutoNode = "BathroomFirst";
        }
        else if(GlobalVariables.BathroomDialogueValue == 1)
        {
            GlobalVariables.AutoNode = "BathroomSecond";
        }
        else if(GlobalVariables.BathroomDialogueValue == 2)
        {
            GlobalVariables.AutoNode = "BathroomThird";
        }

        diaRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        diaRunner.startNode = GlobalVariables.AutoNode;
        interaction = FindObjectOfType<Interaction>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fpcscript = player.GetComponent<FirstPersonController>();
        // StartBathroomDialogue();
        // Debug.Log(diaRunner.CurrentNodeName);
    }

    // Update is called once per frame
    void Update()
    {
        if(diaRunner.IsDialogueRunning)
        {
            // fpcscript.enabled = false;
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            interaction.RestrictMovement = true;
        }
        else
        {
            // Debug.Log("here in update");
            // fpcscript.enabled = true;
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            interaction.RestrictMovement = false;
        }

        //TesterControls();
        
    }

    // public void StartBathroomDialogue()
    // {
    //     diaRunner.StartDialogue(talktonode);
    // }

 /*   public void TesterControls()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            GlobalVariables.AutoNode = "DummyDialogue";
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.F3))
        {
            GlobalVariables.BathroomDialogueValue++;
        }
    }*/
}
