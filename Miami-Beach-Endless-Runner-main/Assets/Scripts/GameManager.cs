
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;

        Debug.Log("GAME OVER!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
