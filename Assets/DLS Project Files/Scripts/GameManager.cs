using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);

        if (Instance != null && Instance != this)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        //Load Level 1
        SceneManager.LoadScene(1);
    }


    //Restart The Game
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetGame()
    {
        GlobalVariables.AutoNode = "";
        GlobalVariables.BathroomDialogueValue = 0;

        for(int i = 0; i < GlobalVariables.NPCDialogueValue.Length; i++)
        {
            GlobalVariables.NPCDialogueValue[i] = 0;
        }

        for(int i = 0; i < GlobalVariables.AllFoundWords.Length; i++)
        {
            GlobalVariables.AllFoundWords[i] = false;
        }

        GlobalVariables.GameHasLooped = false;
    }
}
