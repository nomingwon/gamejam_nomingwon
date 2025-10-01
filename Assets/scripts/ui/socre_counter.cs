using UnityEngine;

public class socre_counter : MonoBehaviour
{
    public static socre_counter Instance;
    public float score = 0;
    public float time;
    
    public bool game_end = false;

    public end_game gameOverUI; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void add_score(float amount)
    {
        if (game_end) return; 

        score += amount;

        if (score < 0)
        {
            score = 0;
            game_end = true; 
            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
        }
    }

    private void Update()
    {
        if (game_end) return; 

        
        time += Time.deltaTime;
    }
}
