using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
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
}
