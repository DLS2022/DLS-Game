using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using StarterAssets;

public class SetPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PRESS R TO USE - TEST ONLY - Spawns Player In Bath Room")]
    Transform bathRoomTargetPosition;

    [SerializeField]
    [Tooltip("PRESS E TO USE - TEST ONLY - Spawns Player In Main Room")]
    Transform mainRoomTargetPosition;

    [SerializeField]
    [Tooltip("DOOR TRIGGER ACIVATED - Add The Spawn Location You Want The Door To Take You To")]
    Transform targetPosition;

    [SerializeField]
    [Tooltip("Character Controller")]
    CharacterController controller;

    [SerializeField]
    [Tooltip("UI FADE TO BLACK PANEL")]
    GameObject blackPanel;

    GameObject player;

    private bool canInteract;

    //bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        /*player = GameObject.FindWithTag("Player");
        controller = player.GetComponent<FirstPersonController>(); */
        controller = FindObjectOfType<CharacterController>() as CharacterController;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing Out System
        //Main Room
        if (Input.GetKeyDown(KeyCode.E))
        {
            controller.transform.position = mainRoomTargetPosition.transform.position;
            controller.enabled = false;

            if (controller.transform.position == mainRoomTargetPosition.transform.position)
            {
                controller.enabled = true;
                canInteract = false;
            }
        }

        //Bathroom
        if (Input.GetKeyDown(KeyCode.R))
        {
            controller.transform.position = bathRoomTargetPosition.transform.position;
            controller.enabled = false;

            if (controller.transform.position == bathRoomTargetPosition.transform.position)
            {
                controller.enabled = true;
                canInteract = false;
            } 
        }


        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Screen Fades to black for .5f seconds
                StartCoroutine(FadeToBlack());
             
                
                //One Way Doors
                controller.transform.position = targetPosition.transform.position;
                controller.enabled = false;


                if (controller.transform.position == targetPosition.transform.position)
                {
                    
                    canInteract = false;
                    controller.enabled = true;
                }
            }
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


    //Setting the screen to black when walking through a door
    IEnumerator FadeToBlack()
    {
        blackPanel.SetActive(true);
        //controller.enabled = false; //This Line Causes the character controller to throw an error while inputs are disabled
        yield return new WaitForSeconds(.5f);
        blackPanel.SetActive(false);
        //controller.enabled = true;
    }

}
