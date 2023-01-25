using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Score Elements")]
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPanelScoreText;
    public TextMeshProUGUI gameOverPanelHighScoreText;
    
    private void Awake()
    {
        gameOverPanel.SetActive(false);
        GetHighScore();
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highScore;
    }

    public void IncreaseScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();

        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text =  "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highScore.ToString();
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();
        
        gameOverPanel.SetActive(false);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        
        Time.timeScale = 1;
    }
}
