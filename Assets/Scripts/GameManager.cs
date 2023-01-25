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
    public TextMeshProUGUI scoreText;
    
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPanelScoreText;
    
    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void IncreaseScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = "0";
        
        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "Score: 0";

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        
        Time.timeScale = 1;
    }
}
