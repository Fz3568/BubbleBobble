using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextManager : MonoBehaviour
{
    
    [SerializeField] GameObject Level1;

    [SerializeField] private Text text;
   
    // Update is called once per frame
    void Update()
    {
        if (Level1.activeSelf)
        {
            text.enabled = true;
        }

        if (!Level1.activeSelf)
        {
            text.enabled = false;
        }
    }
}
