using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public GameObject gameOverCanvas; // UI Canvas

    private void Start()
    {
        gameOverCanvas.SetActive(false); // ���� �� �����
    }

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // UI ���̱�
            Time.timeScale = 0f;            // ���� ����
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f; // ���� ���� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
    }
}
