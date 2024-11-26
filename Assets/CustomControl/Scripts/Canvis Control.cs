using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvisControl : MonoBehaviour
{
    //The sole purpose of this script to disable canvas on start
    //since I will almost certainly forget to disable it when uploaded the project
    
    [SerializeField] Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }
}
