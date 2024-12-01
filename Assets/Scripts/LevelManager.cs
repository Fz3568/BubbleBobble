using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int CurrentLevel;
    public GameObject Cam;
    public Vector3[] CamPositions;
    Vector3 RefSpeed = Vector3.zero;

    public Text StageTxt;

    public GameObject[] LevelObjs;

    public GameObject GameOverScreen;
    public GameObject YouWinScreen;

    // Update is called once per frame
    void Update()
    {
        StageTxt.text = $"Stage:{CurrentLevel}";
        
        if (Input.GetKeyDown(KeyCode.R) && (GameOverScreen.activeSelf || YouWinScreen.activeSelf))
        {
            RestartScene();
        }

        Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, CamPositions[CurrentLevel - 1], ref RefSpeed, 0.5f);
        
    }

    void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextStage()
    {
        CurrentLevel++;
        Invoke("NextActive", 1.1f);
    }

    void NextActive()
    {
        for (int i = 0; i < LevelObjs.Length; i++)
        {
            if (i == CurrentLevel - 1)
            {
                LevelObjs[i].gameObject.SetActive(true);
            }
            else
            {
                LevelObjs[i].gameObject.SetActive(false);
            }
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void YouWin()
    {
        YouWinScreen.SetActive(true);
    }
}
