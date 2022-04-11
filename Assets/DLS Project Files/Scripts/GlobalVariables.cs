using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    // node for the bathroom dialogue
    public static string AutoNode = "";

    // value for which bathroom dialogue node to load into
    public static int BathroomDialogueValue;

    public static int[] NPCDialogueValue = new int[4];
    
    /*
    [0] Jock
    [1] Mom
    [2] Pun
    */

    /*
    0 - First Loop
    1 - Lose Dialogue
    2 - Win Dialogue
    3 - Second Loop
    */

    public static bool[] AllFoundWords = new bool[3];

    public static bool GameHasLooped;

    public static string FirstWord = "_ _ _ _ _ _ _ _ _";
    public static string SecondWord = "_ _ _ _ _ _ _ _ _";
    public static string ThirdWord = "_ _ _";
}
