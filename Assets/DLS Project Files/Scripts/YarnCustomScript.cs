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

        arbitraryObject = this.gameObject;
    }

    private void EndConversation(GameObject gameobj)
    {   
        Debug.Log("here");
        arbitraryObject.SetActive(true);
    }
}
