using System;
using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class CharacterHealth : MonoBehaviour
    {
        private Health _health;
        private CharacterStatsSO _stats;

        private void Start()
        {
            _health = new Health(_stats.Health);
        }

        [Inject] public void Construct(CharacterStatsSO health)
        {
            _stats = health;
        }

        public void TakeDamage(byte damage)
        {
            _health.CurrentHealth = (byte)Mathf.Clamp(_health.CurrentHealth - damage, 0, _health.CurrentHealth);

            if (_health.CurrentHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
