using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCustomScript : MonoBehaviour
{
    private GameObject arbitraryObject;
    public DialogueRunner diaRunner;

    // Start is called before the first frame update
    void Awake()
    {
        diaRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        diaRunner.AddCommandHandler<GameObject>("endconvo", EndConversation);
        diaRunner.AddCommandHandler<GameObject>("incrementbathvalue", IncrementBathValue);
        // diaRunner.AddCommandHandler<GameObject>("setnpcvalue", SetNPCValue);

        arbitraryObject = this.gameObject;
    }

    private void EndConversation(GameObject gameobj)
    {   
        Debug.Log("here");
        arbitraryObject.SetActive(true);
    }

    private void IncrementBathValue(GameObject gameobj)
    {
        GlobalVariables.BathroomDialogueValue++;
    }

    // [YarnCommand("setnpcvalue")]
    // private void SetNPCValue(GameObject gameobj, int npc , string dialoguevalue)
    // {
    //     if(dialoguevalue == "lose")
    //     {
    //         GlobalVariables.NPCDialogueValue[npc] = 1;
    //     }
    //     else if(dialoguevalue == "win")
    //     {
    //         GlobalVariables.NPCDialogueValue[npc] = 2;
    //     }
    // }
}
