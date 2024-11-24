using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTime = 60f;  // Game duration in seconds
    public Text timerText;

    private void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + ScoreManager.instance.scoreText.text);
        // Optionally restart the game or go to a game over screen
    }
}
