using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    // node for the bathroom dialogue
    public static string AutoNode = "";

    // value for which bathroom dialogue node to load into
    public static int BathroomDialogueValue;

    /*
    [0] Jock
    [1] Mom
    [2] Pun
    */
    public static int[] NPCDialogueValue = new int[3];
}
