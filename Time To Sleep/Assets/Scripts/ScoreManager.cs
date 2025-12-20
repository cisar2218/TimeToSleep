using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;

    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highestScoreText;

    private void Start()
    {
        if (currentScoreText == null || highestScoreText == null)
        {
            Debug.LogWarning("One of the score text objects is not assigned. The score will not be displayed.");
            return;
        }
        DisplayUpdatedScore();
    }
    public void AddScore(int ammount)
    {
        currentScore += ammount;
        if (currentScore > PlayerPrefs.GetInt("highestScore"))
            PlayerPrefs.SetInt("highestScore", currentScore);

        if (currentScoreText == null || highestScoreText == null)
        {
            return;
        }
        DisplayUpdatedScore();
    }
    private void DisplayUpdatedScore()
    {
        currentScoreText.text = "Score: " + currentScore.ToString();
        highestScoreText.text = "Highest score: " + PlayerPrefs.GetInt("highestScore").ToString();
    }

    [ContextMenu("Add Score")]
    private void ExampleScoreAdd()
    {
        AddScore(1);
    }
}