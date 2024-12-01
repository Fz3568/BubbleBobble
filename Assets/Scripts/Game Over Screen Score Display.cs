using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
      }

      if (YouWinScreen.activeSelf)
      {
         updateWinScore();
      }
   }

   void updateLoseScore()
   {
      textScoreLose.text = "Score: " + Dino.score.ToString();
   }

   void updateWinScore()
   {
      textScoreWin.text = "Score: " + Dino.score.ToString("00");
   }
}
