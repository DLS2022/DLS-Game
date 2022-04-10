using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using StarterAssets;

public class Interaction : MonoBehaviour
{

    [Header("Yarn Components")]
    public string CurrConvo;
    public string ConvoFirst;
    public string ConvoLose;
    public string ConvoWin;
    public string ConvoBye;
    public int NPCValue;

    public DialogueRunner diaRunner;

    public GameObject player;
    public FirstPersonController fpcscript;
    // public GameObject randoObj;

    // private bool isCurrentlySpeaking;
    bool canInteract;

    void Awake()
    {
        diaRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        // diaRunner.AddCommandHandler<GameObject>("endconvo", EndConversation);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fpcscript = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !diaRunner.IsDialogueRunning)
            {
                //Player Dialogue can be activated
                Debug.Log("You hit the trigger");
                StartConversation();
            } 
        }

        if(diaRunner.IsDialogueRunning)
        {
            fpcscript.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Debug.Log("here in update");
            fpcscript.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(GlobalVariables.NPCDialogueValue[NPCValue] == 0)
        {
            CurrConvo = ConvoFirst;
        }
        else if(GlobalVariables.NPCDialogueValue[NPCValue] == 1)
        {
            CurrConvo = ConvoLose;
        }
        else if(GlobalVariables.NPCDialogueValue[NPCValue] == 2)
        {
            CurrConvo = ConvoWin;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }

    private void StartConversation()
    {
        diaRunner.StartDialogue(CurrConvo);
    }

    [YarnCommand("setnpcvalue")]
    private void SetNPCValue(GameObject gameobj, int npc , string dialoguevalue)
    {
        if(dialoguevalue == "lose")
        {
            GlobalVariables.NPCDialogueValue[npc] = 1;
        }
        else if(dialoguevalue == "win")
        {
            GlobalVariables.NPCDialogueValue[npc] = 2;
        }
    }
}
