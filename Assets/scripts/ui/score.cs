using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    private void Update()
    {
        if (socre_counter.Instance != null)
        {
            // �Ҽ��� ��° �ڸ����� ǥ��
            scoretext.text = "Score : " + socre_counter.Instance.score.ToString("F2");
        }
    }
}
