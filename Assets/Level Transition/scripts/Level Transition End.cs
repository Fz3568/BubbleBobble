using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionEnd : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      //so basically this code will detect if player has reached the end of level transition using collsion,
      //then modify the isInTransition to true so player can shoot again
      if (other.CompareTag("Player"))
      {
         LevelTransitionStart.isInTransition = false;
      }
   }
}
