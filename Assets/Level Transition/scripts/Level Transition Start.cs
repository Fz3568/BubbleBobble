using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTransitionStart : MonoBehaviour
{
    public LevelTransitionStart connectedLevelTransition;
    public LevelTransitionEnd endPosition;
    public Dino dino;//this is player
    public static bool isInTransition = false;

    public float moveDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MovePlayerToPosition(connectedLevelTransition.endPosition.transform.position));
            isInTransition = true;
        }
    }
    
    private IEnumerator MovePlayerToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = dino.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            // Smoothly interpolate the player's position
            dino.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);

            yield return null; // Wait for the next frame
            
        }

        // Ensure the player ends exactly at the target position
        dino.transform.position = targetPosition;

    }
}
