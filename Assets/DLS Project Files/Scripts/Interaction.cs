using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using StarterAssets;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    [Header("Yarn Components")]
    public string CurrConvo;
    public string ConvoFirst;
    public string ConvoLose;
    public string ConvoWin;
    public string ConvoBye;
    public string ConvoLoop;
    public int NPCValue;

    [SerializeField]
    [Tooltip("Spacebar Image for the Interaction propmt")]
    GameObject spaceBarImage;

    [SerializeField]
    [Tooltip("This is the text for game objects name to be displayed")]
    TextMeshProUGUI roomText;

    [SerializeField]
    [Tooltip("UI FADE TO BLACK PANEL")]
    public Image blackPanel;

    public DialogueRunner diaRunner;

    public GameObject player;
    public FirstPersonController fpcscript;
    public bool RestrictMovement;

    //public ContinueActionType continueActionType = ContinueActionType.KeyCode;
    //public KeyCode continueActionKeyCode = KeyCode.Space;

    public Animator FadeAnimation;

    PauseGame pause;
    // public GameObject randoObj;

    // private bool isCurrentlySpeaking;
    bool canInteract;

    void Awake()
    {
        diaRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        pause = FindObjectOfType<PauseGame>();
        blackPanel.CrossFadeAlpha(0, 3f, false);

        // if(GlobalVariables.NPCDialogueValue[NPCValue] == 2)
        // {
        //     CurrConvo = ConvoWin;
        // }

         if(GlobalVariables.NPCDialogueValue[NPCValue] == 1)
         {
             if(GlobalVariables.GameHasLooped)
             {
                 GlobalVariables.NPCDialogueValue[NPCValue] = 3;
             }
             else
             {
                 GlobalVariables.NPCDialogueValue[NPCValue] = 0;
             }
         }

        // Debug.Log("GameHasLooped is " + GlobalVariables.GameHasLooped);
        if(GlobalVariables.GameHasLooped)
        {
            CurrConvo = ConvoLoop;
        }

        // if(GlobalVariables.NPCDialogueValue[NPCValue] == 2)
        // {
        //     CurrConvo = ConvoWin;
        // }
        

        // diaRunner.AddCommandHandler<GameObject>("endconvo", EndConversation);

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fpcscript = player.GetComponent<FirstPersonController>();

        // blackPanel = GameObject.FindWithTag("BlackScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //&& !diaRunner.IsDialogueRunning)
            {
                spaceBarImage.SetActive(false);

                //Player Dialogue can be activated
                //Debug.Log("You hit the trigger");
                StartConversation();

                if (this.gameObject.tag == ("NPC"))
                {
                    SoundManager.instance.sound.PlayOneShot(SoundManager.instance.interactionSFX);
                }

                if (this.gameObject.tag == ("BathroomDoor") || (this.gameObject.tag == ("Bedroom")))
                {
                    SoundManager.instance.sound.volume = .6f;
                    SoundManager.instance.sound.PlayOneShot(SoundManager.instance.doorRattle);
                }
                else
                {
                    SoundManager.instance.sound.volume = 1f;
                }
            } 
        }

        // if(NPCValue == 2)
        // {
        //     Debug.Log("GlobalVariables.NPCDialogueValue[NPCValue] is " + GlobalVariables.NPCDialogueValue[NPCValue]);
        // }

        if(diaRunner.IsDialogueRunning)
        {
            // fpcscript.enabled = false;
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            RestrictMovement = true;
        }
        else
        {
            // Debug.Log("here in update");
            // fpcscript.enabled = true;
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            RestrictMovement = false;
        }

        if(RestrictMovement || pause.gameIsPaused)
        {
            fpcscript.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
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
        else if(GlobalVariables.NPCDialogueValue[NPCValue] == 3)
        {
            CurrConvo = ConvoLoop;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
        spaceBarImage.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
        spaceBarImage.SetActive(false);
    }

    private void StartConversation()
    {
        diaRunner.StartDialogue(CurrConvo);
    }

    // example: <<setnpcvalue PartyJockNPC this 0 win>>
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
        else if(dialoguevalue == "looped")
        {
            GlobalVariables.NPCDialogueValue[npc] = 3;
        }

        // if(dialoguevalue == "win")
        // {
        //     GlobalVariables.NPCDialogueValue[npc] = 2;
        // }
        // else
        // {
        //     if(dialoguevalue == "lose")
        //     {
        //         GlobalVariables.NPCDialogueValue[npc] = 1;
        //     }
        //     else if(dialoguevalue == "looped")
        //     {
        //         GlobalVariables.NPCDialogueValue[npc] = 3;
        //     }
        // }
    }

    [YarnCommand("resetscene")]
    private void ResetScene(GameObject gameobj)
    {
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        // blackPanel.SetActive(true);
        fpcscript.enabled = false; //This Line Causes the character controller to throw an error while inputs are disabled
        blackPanel.CrossFadeAlpha(1, 1f, false);

        // Outside Door Opening Sound
        SoundManager.instance.sound.PlayOneShot(SoundManager.instance.doorOpen2);
        Debug.Log("GameHasLooped is " + GlobalVariables.GameHasLooped);
        // FadeAnimation.Play("BlackFadeAnimation");
        yield return new WaitForSecondsRealtime(1f);
        // blackPanel.SetActive(false);
        fpcscript.enabled = true;

        yield return new WaitForSecondsRealtime(0.1f);
        // GlobalVariables.GameHasLooped = true;
        Debug.Log("GameHasLooped is " + GlobalVariables.GameHasLooped);
        SceneManager.LoadScene(1);
    }
}
