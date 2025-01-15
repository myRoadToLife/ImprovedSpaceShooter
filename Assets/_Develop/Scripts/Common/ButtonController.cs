using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace _Develop.Scripts.Common
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private Button[] _homeButtons;
        [SerializeField] private Button _retryButton;
        [Inject] private FadeCanvas _fadeCanvas;

        public void LoadLevelString(string levelName)
        {
            _fadeCanvas.FaderLoadString(levelName);
            Debug.Log("Сцена загружена");
        }
        
        public void RestartLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            _fadeCanvas.FadeLoadInt(currentScene);
        }

        public void OnEnable()
        {
            _retryButton.onClick.AddListener(RestartLevel);

            foreach (Button button in _homeButtons)
            {
                button.onClick.AddListener(() => LoadLevelString("Level1"));
            }
        }

        private void OnDestroy()
        {
            foreach (Button button in _homeButtons)
            {
                button.onClick.RemoveAllListeners();
            }

            _retryButton.onClick.RemoveAllListeners();
        }
    }
}
