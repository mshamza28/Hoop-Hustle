using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;

    private int score = 0;
    private float gameTime = 60.0f;
    public bool isGameActive;

    private void Awake()
    {
        instance = this;
        isGameActive = false;
    }

    private void Update()
    {
        if (isGameActive) 
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                Timer();
        }
            else
            {
                EndGame();
            }
        }
        
    }
    public void AddPoints(int addPoints)
    {
        score += addPoints;
        scoreText.text = "Score: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + ScoreManager.instance.scoreText.text);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void StartGame()
    {
        isGameActive = true;
        Timer();
        AddPoints(0);
        titleScreen.gameObject.SetActive(false);

    }
    private void Timer()
    {
        timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
    }
}
