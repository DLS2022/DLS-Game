using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHyperLink : MonoBehaviour
{

    public void CreateHyperLink(string link)
    {
        Application.OpenURL(link);
    }
}
