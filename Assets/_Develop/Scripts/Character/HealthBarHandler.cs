using _Develop.Scripts.UI;

namespace _Develop.Scripts.Character
{
    public class HealthBarHandler
    {
        private readonly HealthBarView _healthBarView;

        public HealthBarHandler(HealthBarView healthBarView)
        {
            _healthBarView = healthBarView;
        }

        public void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            _healthBarView.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
}
