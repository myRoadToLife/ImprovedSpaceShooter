using _Develop.Scripts.Character;
using _Develop.Scripts.Common;
using _Develop.Scripts.Common.Interfaces;
using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Enemy.Meteors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Meteor : MonoBehaviour, IDamageable, ISequence
    {
        protected Stats _stats;
        protected byte _damage;
        protected Health _health;
        protected Rigidbody2D _rb2D;

        [Inject] public void Construct(Stats stats)
        {
            _stats = stats;
            Initialize(_stats);
        }

        protected abstract void Initialize(Stats stats);
        
        public void TakeDamage(byte damage)
        {
            _health.CurrentHealth = (byte)Mathf.Clamp(_health.CurrentHealth - damage, 0, _health.CurrentHealth);

            SequenceHurt();

            if (_health.CurrentHealth == 0)
            {
                SequenceDeath();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<MonoBehaviour>() is not ICharacter character)
                return;

            Destroy(((MonoBehaviour)character).gameObject);
            Debug.Log("Бам");
        }

        public void SequenceHurt()
        {
        }

        public void SequenceDeath()
        {
            Destroy(gameObject);
        }
    }
}
