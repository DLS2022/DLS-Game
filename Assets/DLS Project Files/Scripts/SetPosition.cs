using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private bool canInteract;

    //bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController controller = GetComponent(typeof(CharacterController)) as CharacterController; 
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
                //One Way Doors
                controller.transform.position = targetPosition.transform.position;
                controller.enabled = false;

                if (controller.transform.position == targetPosition.transform.position)
                {
                    controller.enabled = true;
                    canInteract = false;
                }
            }
        }



    }



    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

}
