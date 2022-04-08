using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Player Dialogue can be activated
                Debug.Log("You hit the trigger");
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

}
