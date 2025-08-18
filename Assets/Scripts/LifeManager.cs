using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public Image[] hearts;
    public GameObject gameOverPanel;

    private int lives;
    private bool gameStarted = false;

    private void Start()
    {
        lives = hearts.Length;
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (!gameStarted)
        {
#if UNITY_ANDROID
            if (Input.touchCount > 0)
                gameStarted = true;
#else
            if (Input.GetMouseButtonDown(0))
                gameStarted = true;
#endif
        }
    }

    public void LoseLife()
    {
        if (!gameStarted) return;

        lives--;
        hearts[lives].enabled = false;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        gameStarted = false;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}