using UnityEngine;
using UnityEngine.UI;

namespace _Develop.Scripts.UI
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            _image.fillAmount = currentHealth / maxHealth;
        }
    }
}
