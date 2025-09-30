using UnityEngine;

public class socre_counter : MonoBehaviour
{
    public static socre_counter Instance;
    public float score = 0;
    public float time;
    private float elapsed;
    public bool game_end = false;

    public end_game gameOverUI; // UI 스크립트 연결

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void add_score(float amount)
    {
        if (game_end) return; // 게임 끝나면 점수 변화 무시

        score += amount;

        if (score <= 0)
        {
            score = 0;
            game_end = true; // 게임 끝
            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
        }
    }

    private void Update()
    {
        if (game_end) return; // 게임 끝나면 시간 증가도 중지

        elapsed += Time.deltaTime;
        time += Time.deltaTime;
    }
}
