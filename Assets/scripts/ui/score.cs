using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    private void Update()
    {
        if (socre_counter.Instance != null)
        {
            // 소수점 둘째 자리까지 표시
            scoretext.text = "Score : " + socre_counter.Instance.score.ToString("F2");
        }
    }
}
