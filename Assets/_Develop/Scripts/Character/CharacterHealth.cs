using System.Collections;
using _Develop.Scripts.Character.UI;
using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using _Develop.Scripts.VFX;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class CharacterHealth : MonoBehaviour
    {
        private CharacterStatsSO _stats;
        private Health _health;
        private HealthBarView _healthBarView;
        private ExplosionFactory _explosionFactory;
        private CharacterAnimation _characterAnimation;

        private DiContainer _container;

        private bool _canPlayAnim = true;

        [Inject] public void Construct(
            CharacterStatsSO health,
            HealthBarView healthBarView,
            ExplosionFactory explosionFactory,
            DiContainer diContainer,
            CharacterAnimation characterAnimation)
        {
            _healthBarView = healthBarView;
            _stats = health;
            _explosionFactory = explosionFactory;
            _container = diContainer;
            _characterAnimation = characterAnimation;
            
            _health = new Health(_stats.Health);
            _healthBarView.UpdateHealthBar(_health.CurrentHealth, _health.MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            _health.CurrentHealth = (float)Mathf.Clamp(_health.CurrentHealth - damage, 0, _health.CurrentHealth);
            _healthBarView.UpdateHealthBar(_health.CurrentHealth, _health.MaxHealth);

            if (_canPlayAnim)
            {
                if (_characterAnimation != null)
                {
                    _characterAnimation.TakeDamageAnimation();
                }
                else
                {
                    Debug.LogError("CharacterAnimation is null!");
                }

                StartCoroutine(AntiSpamAnimation());
            }

            if (_health.CurrentHealth == 0)
            {
                Explosion explosion = _explosionFactory.Create(transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        IEnumerator AntiSpamAnimation()
        {
            _canPlayAnim = false;
            yield return new WaitForSeconds(0.15f);
            _canPlayAnim = true;
        }
    }
}
