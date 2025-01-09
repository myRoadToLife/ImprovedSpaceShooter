using System;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Ships
{
    public class GreenShip : Enemy
    {
        private float _moveSpeed;

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            Damage = StatsShipsSo.GreenDamage;
            HealthValue = new Health(StatsShipsSo.GreenHealth);
            _moveSpeed = Random.Range(StatsShipsSo.GreenMinSpeed, StatsShipsSo.PurpleMaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }

        public override void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
