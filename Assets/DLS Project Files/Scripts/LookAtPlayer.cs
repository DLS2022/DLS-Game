using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Player Characters Transform Position")]
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Look at the Player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

    }

    void OnTriggerStay(Collider other)
    {
        //Sphere Collider is the trigger
        //Engage Dialogue
    }
}
