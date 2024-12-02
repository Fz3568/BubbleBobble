using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void MainMenu()
    {
        LoadScene(0);
    }
    public void PlayGame()
    {
        LoadScene(1);
    }

    public void SettingsMenu()
    {
        LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

#if UNITY_EDITOR

    UnityEditor.EditorApplication.isPlaying = false;

#else

    Application.Quit();

#endif
    }

}
