using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public GameObject gameOverCanvas; // UI Canvas

    private void Start()
    {
        gameOverCanvas.SetActive(false); // 시작 시 숨기기
    }

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // UI 보이기
            Time.timeScale = 0f;            // 게임 정지
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f; // 게임 정지 해제
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
    }
}
