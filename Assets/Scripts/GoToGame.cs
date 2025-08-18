using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuUI;

    public void StartGame()
    {
        SceneManager.LoadScene("FootBall");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
