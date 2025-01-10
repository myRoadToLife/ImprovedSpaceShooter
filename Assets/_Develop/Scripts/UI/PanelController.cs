using UnityEngine;

namespace _Develop.Scripts.UI
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Transform _winScreen;
        [SerializeField] private Transform _loseScreen;
        
        public void ShowWinScreen()
        {
            _canvasGroup.alpha = 1;
            _winScreen.gameObject.SetActive(true);
        }

        public void ShowLoseScreen()
        {
            _canvasGroup.alpha = 1;
            _loseScreen.gameObject.SetActive(true);
        }
    }
}
