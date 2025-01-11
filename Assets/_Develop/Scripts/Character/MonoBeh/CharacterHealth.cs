using _Develop.Configs;
using _Develop.Scripts.Common;
using _Develop.Scripts.UI;
using _Develop.Scripts.VFX;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character.MonoBeh
{
    public class CharacterHealth : MonoBehaviour
    {
        private CharacterStats _stats;
        private HealthBarHandler _healthBarHandler;
        private CharacterAnimationHandler _animationHandler;
        private ExplosionFactory _explosionFactory;
        private EndLevelManager _endLevelManager;

        [Inject] public void Construct(
            CharacterStatsSO health,
            HealthBarView healthBarView,
            ExplosionFactory explosionFactory,
            CharacterAnimation characterAnimation,
            EndLevelManager endLevelManager)
        {
            _stats = new CharacterStats(health.Health);
            _healthBarHandler = new HealthBarHandler(healthBarView);
            _animationHandler = new CharacterAnimationHandler(characterAnimation);
            _explosionFactory = explosionFactory;
            _endLevelManager = endLevelManager;

            _healthBarHandler.UpdateHealthBar(_stats.CurrentHealth, _stats.MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            _stats.TakeDamage(damage);
            _healthBarHandler.UpdateHealthBar(_stats.CurrentHealth, _stats.MaxHealth);

            if (_stats.IsDead)
            {
                _endLevelManager.SetGameOver(true);
                _ = _endLevelManager.FinishGame();

                Explosion explosion = _explosionFactory.Create(transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                _animationHandler.PlayDamageAnimation();
            }
        }
    }
}
