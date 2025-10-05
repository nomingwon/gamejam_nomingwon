using UnityEngine;
using UnityEngine.SceneManagement;

public class main_manu : MonoBehaviour
{
    public class MainMenuInspector : MonoBehaviour
    {
        [SerializeField] private string gameSceneName = "test"; // ���忡 ����� �� �̸�

        // �ν������� Button OnClick()�� �����ؼ� ���
        public void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
