using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timetext;

    private void Update()
    {
        if (socre_counter.Instance != null)
        {
            // 소수점 둘째 자리까지 표시
            timetext.text = "Time : " + socre_counter.Instance.time.ToString("F2");
        }
    }
}
