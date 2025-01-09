using System;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Dangerous : Enemy
    {
        [SerializeField] private float _rotateSpeed;

        private float _moveSpeed;

      public override void OnBecameInvisible() => Destroy(gameObject);

        public override void Initialize()
        {
            Damage = StatsMeteorSo.DangerousDamage;
            HealthValue = new Health(StatsMeteorSo.DangerousHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.DangerousMinSpeed, StatsMeteorSo.DangerousMaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
    }
}
