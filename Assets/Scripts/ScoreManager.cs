using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        InvokeRepeating("IncreaseScore", 1f, 1f);  //calls IncreaseScore once/second 
    }

    void IncreaseScore()
    {
        score += 3;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score : {score}";
    }

    void UpdateHighScoreText()
    {
        highScore.text = $"High score: {LoadHighScore()}";
    }

    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
