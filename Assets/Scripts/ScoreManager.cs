using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// This class is responsible for Score in the game
public class ScoreManager : MonoBehaviour
{
    public int score;
    
    // An event to update the score-value automatically
    public static event Action<int> UpdatedScore = delegate { };
    
    private void Start()
    {
        Reset();
    }
    // Re-initialize the score
    private void Reset()
    {
        score = 0;
        UpdatedScore(score);
    }
    // This method adds a predefined value to the result each time
    public void AddScore(int amount)
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.score);
        score += amount;
        UpdatedScore(score);
    }

}
