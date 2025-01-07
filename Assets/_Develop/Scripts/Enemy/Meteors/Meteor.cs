using System;
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
        public StatsMeteorSO StatsMeteorSo { get; protected set; }
        public byte Damage { get; protected set; }
        public Health Health { get; protected set; }

        [Inject] public void Construct(StatsMeteorSO statsMeteorSo)
        {
            StatsMeteorSo = statsMeteorSo;
            Initialize(StatsMeteorSo);
        }

        protected abstract void Initialize(StatsMeteorSO statsMeteorSo);

        public void TakeDamage(byte damage)
        {
            Health.CurrentHealth = (byte)Mathf.Clamp(Health.CurrentHealth - damage, 0, Health.CurrentHealth);

            SequenceHurt();

            if (Health.CurrentHealth == 0)
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

        public abstract void OnBecameInvisible();
    }
}
