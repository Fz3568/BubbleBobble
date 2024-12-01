using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Dino dino;
    public int[] ScoreThresholds;
    public GameObject[] TransitionSets;
    int currentSet;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSet = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ScoreThresholds.Length; i++)
        {
            if (Dino.score >= ScoreThresholds[i])
            {
                currentSet = i;
            }
        }
        
        for (int i = 0; i < TransitionSets.Length; i++)
        {
            if (i == currentSet)
            {
                TransitionSets[i].gameObject.SetActive(true);
            }
            else
            {
                TransitionSets[i].SetActive(false);
            }
        }
    }
}
