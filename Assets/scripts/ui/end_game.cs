using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    public GameObject gameOverCanvas; 

    private void Start()
    {
        gameOverCanvas.SetActive(false); 
    }

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); 
            Time.timeScale = 0f;            
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
