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
        public StatsMeteorSO StatsMeteorSo { get; private set; }
        public byte Damage { get; protected set; }
        public Health HealthValue { get; protected set; }

        private CharacterHealth _characterHealth;

        [Inject] public void Construct(StatsMeteorSO statsMeteorSo, CharacterHealth characterHealth)
        {
            StatsMeteorSo = statsMeteorSo;
            _characterHealth = characterHealth;

            Initialize();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();

            if (characterHealth != null)
            {
                characterHealth.TakeDamage(Damage);
                Destroy(gameObject);
            }
            
        }

        public void TakeDamage(byte damage)
        {
            HealthValue.CurrentHealth = (byte)Mathf.Clamp(HealthValue.CurrentHealth - damage, 0, HealthValue.CurrentHealth);
            
            SequenceHurt();

            if (HealthValue.CurrentHealth == 0)
            {
                SequenceDeath();
            }
        }

        public void SequenceHurt()
        {
            // Реализация действия при повреждении
        }

        public void SequenceDeath()
        {
            Destroy(gameObject);
        }

        public abstract void OnBecameInvisible();

        protected abstract void Initialize();
    }
}
