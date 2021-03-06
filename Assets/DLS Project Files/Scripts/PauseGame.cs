using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Pause Menu UI")]
    GameObject pauseMenu;

    [SerializeField]
    [Tooltip("Dialogue System")]
    GameObject dialogueSystem;

    [SerializeField]
    [Tooltip("Drag the Player Object here")]
    FirstPersonController fpcscript;

    [SerializeField]
    [Tooltip("Drag the Player Object here")]
    GameObject player;

    public bool gameIsPaused;

    Interaction interaction;


    // Start is called before the first frame update
    void Start()
    {
        interaction = FindObjectOfType<Interaction>();
        player = GameObject.FindWithTag("Player");
        fpcscript = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) 
            && !interaction.diaRunner.IsDialogueRunning
            )
        {
            gameIsPaused = !gameIsPaused;
            pauseMenu.SetActive(!pauseMenu.gameObject.activeSelf);
        }

        if (gameIsPaused)
        {
            // fpcscript.enabled = false;
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            interaction.RestrictMovement = true;
            dialogueSystem.SetActive(false);
        }
        else
        {
            // fpcscript.enabled = true;
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            interaction.RestrictMovement = false;
            dialogueSystem.SetActive(true);
        }


    }
}
