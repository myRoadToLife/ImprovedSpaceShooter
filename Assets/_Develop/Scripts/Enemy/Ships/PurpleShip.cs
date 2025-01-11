using System.Collections;
using _Develop.Configs;
using _Develop.Scripts.Common;
using _Develop.Scripts.Enemy.Ships.Projectiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Ships
{
    public class PurpleShip : Enemy
    {
        [SerializeField] private Transform _leftPointShoot;
        [SerializeField] private Transform _rightPointShoot;
        [SerializeField] private PurpleBullet _purpleBulletPrefab;

        [SerializeField] private  StatsShipsSO _statsShip;
        
        private StatsShipsSO.ShipStat _stat;

        private float _moveSpeed;
        private bool _isShooting = true;

        private void Start()
        {
            Initialize();
            StartCoroutine(Shooting());
        }

        IEnumerator Shooting()
        {
            while (_isShooting)
            {
                yield return new WaitForSeconds(_stat.FireRate);
                Instantiate(_purpleBulletPrefab, _leftPointShoot.position, Quaternion.identity);
                Instantiate(_purpleBulletPrefab, _rightPointShoot.position, Quaternion.identity);
            }
        }

        public override void OnBecameInvisible() => Destroy(gameObject);

        public override void Initialize()
        {
            _stat = _statsShip.GetShipStats(StatsShipsSO.ShipType.Purple);
            Damage = _stat.Damage;
            HealthValue = new Health(_stat.Health);
            _moveSpeed = Random.Range(_stat.MinSpeed, _stat.MaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
    }
}
