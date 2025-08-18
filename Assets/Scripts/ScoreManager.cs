using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public ThemeManager themeManager;  

    private int score = 0;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        if (Time.timeScale == 0f)
            return;

        score += amount;
        UpdateScoreUI();

        if (themeManager != null)
        {
            themeManager.CheckScore(score);
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
