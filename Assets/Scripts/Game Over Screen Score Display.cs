using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverScreenScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text textScoreLose;
    [SerializeField] private Text textScoreWin;

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject YouWinScreen;
    private void Update()
    {
        if (GameOverScreen.activeSelf)
        {
            updateLoseScore();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Dino.score = 0;
            }
        }

        if (YouWinScreen.activeSelf)
        {
            updateWinScore();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Dino.score = 0;
            }
        }
    }

    void updateLoseScore()
    {
        textScoreLose.text = "Score: " + Dino.score.ToString() + "0";
    }

    void updateWinScore()
    {
        textScoreWin.text = "Score: " + Dino.score.ToString() + "0";
    }


}
