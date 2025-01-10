using System;
using _Develop.Scripts.Character;
using _Develop.Scripts.Character.MonoBeh;
using _Develop.Scripts.Common;
using _Develop.Scripts.Common.Interfaces;
using _Develop.Scripts.Configs;
using _Develop.Scripts.VFX;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class Enemy : MonoBehaviour, IDamageable, ISequence
    {
        public StatsMeteorSO StatsMeteorSo { get; private set; }
        public StatsShipsSO StatsShipsSo { get; private set; }
        public float Damage { get; protected set; }
        public Health HealthValue { get; protected set; }

        [field: SerializeField] public Rigidbody2D Rb2D { get; private set; }

        private CharacterHealth _characterHealth;
        private ExplosionFactory _explosionFactory;
        private DiContainer _container;

        private void Start()
        {
            Initialize();
        }

        [Inject] public void Construct(
            StatsMeteorSO statsMeteorSo,
            StatsShipsSO statsShipsSo,
            CharacterHealth characterHealth,
            DiContainer container,
            ExplosionFactory explosionFactory)
        {
            StatsMeteorSo = statsMeteorSo;
            StatsShipsSo = statsShipsSo;
            _characterHealth = characterHealth;
            _container = container;
            _explosionFactory = explosionFactory;
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

        public void TakeDamage(float damage)
        {
            HealthValue.CurrentHealth = Mathf.Clamp(HealthValue.CurrentHealth - damage, 0, HealthValue.CurrentHealth);

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
            Explosion explosion = _explosionFactory.Create(transform.position, transform.rotation);

            Destroy(gameObject);
        }

        public abstract void Initialize();

        public abstract void OnBecameInvisible();
    }
}
