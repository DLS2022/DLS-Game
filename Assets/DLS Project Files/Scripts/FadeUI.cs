/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Canvas Group you want to effect")]
    CanvasGroup myUIGroup;

    [SerializeField]
    [Tooltip("The Object will fade in")]
    bool fadeIn = false;

    [SerializeField]
    [Tooltip("The Object will fade out")]
    bool fadeOut = false;

    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeOut = true;
    }

    void Update()
    {
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha > 1)
                {
                    fadeIn = false;
                }
            }

        }

        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }

        }

    }

}*/
