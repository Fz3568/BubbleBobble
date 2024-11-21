using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private InputAction pauseGame;
    [SerializeField] private Canvas canvas;
    
    public static bool isPaused = false;

    private void OnEnable()
    {
        pauseGame.Enable();
    }

    private void OnDisable()
    {
        pauseGame.Disable();
    }
    
    void Start()
    {
        pauseGame.performed += _ => Pause();
    }

    public void Pause()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            canvas.enabled = false;
        }
    }
}
