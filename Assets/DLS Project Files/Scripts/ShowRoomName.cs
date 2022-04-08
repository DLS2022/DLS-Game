using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowRoomName : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the text for game objects name to be displayed")]
    TextMeshProUGUI roomText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (FindObjectOfType<CharacterController>())
        {
            Debug.Log(this.name);
            roomText.SetText(this.name);
        }
    }

}
