using System;
using _Develop.Configs;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Ships
{
    public class GreenShip : Enemy
    {
        [SerializeField] StatsShipsSO _statsShip;
        private StatsShipsSO.ShipStat _stat;

        private float _moveSpeed;

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            _stat = _statsShip.GetShipStats(StatsShipsSO.ShipType.Green);

            Damage = _stat.Damage;
            HealthValue = new Health(_stat.Health);
            _moveSpeed = Random.Range(_stat.MinSpeed, _stat.MaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }

        public override void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
