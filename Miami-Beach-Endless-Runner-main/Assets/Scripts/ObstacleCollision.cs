using Mono.Cecil.Cil;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject gameOverText;
    private bool gameOver = false;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.SetActive(false);

        Time.timeScale = 1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameOver)
        {
            gameOver = true;

            if (gameOverText != null)
                gameOverText.SetActive(true);

            Debug.Log("GAME OVER!");
            Time.timeScale = 0f;
        }
    }
}
