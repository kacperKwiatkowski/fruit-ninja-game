using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class GamaManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;

    public void IncreaseScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }
}
