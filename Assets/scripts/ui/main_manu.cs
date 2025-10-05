using UnityEngine;
using UnityEngine.SceneManagement;

public class main_manu : MonoBehaviour
{
    public class MainMenuInspector : MonoBehaviour
    {
        [SerializeField] private string gameSceneName = "test"; // 빌드에 등록한 씬 이름

        // 인스펙터의 Button OnClick()에 연결해서 사용
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
