using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timetext;

    private void Update()
    {
        if (socre_counter.Instance != null)
        {
            // �Ҽ��� ��° �ڸ����� ǥ��
            timetext.text = "Time : " + socre_counter.Instance.time.ToString("F2");
        }
    }
}
