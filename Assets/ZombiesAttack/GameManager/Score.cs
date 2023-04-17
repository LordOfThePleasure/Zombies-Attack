using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int currentScore;
    private int highscore;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;

    public static Score instance;

    private void Awake()
    {
        instance = this;
        SetHighscore(PlayerPrefs.GetInt("Highscore"));
    }

    public void ChangeScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highscore)
        {
            SetHighscore(currentScore);
        }

        currentScoreText.text = "Score: " + currentScore.ToString();
        gameOverScoreText.text = "Your score:\n" + currentScore.ToString();
    }

    private void SetHighscore(int score)
    {
        highscore = score;
        highscoreText.text = "Highscore: " + highscore.ToString();
        PlayerPrefs.SetInt("Highscore", highscore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentScoreText.text = "Score: " + currentScore.ToString();
        gameOverScoreText.text = "Your score:\n" + currentScore.ToString();
    }
}
