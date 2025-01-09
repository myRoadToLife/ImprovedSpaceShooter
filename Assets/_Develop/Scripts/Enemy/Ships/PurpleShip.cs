using System.Collections;
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
                yield return new WaitForSeconds(StatsShipsSo.PurpleFireRate);
                Instantiate(_purpleBulletPrefab, _leftPointShoot.position, Quaternion.identity);
                Instantiate(_purpleBulletPrefab, _rightPointShoot.position, Quaternion.identity);
            }
        }

        public override void OnBecameInvisible() => Destroy(gameObject);

        public override void Initialize()
        {
            Damage = StatsShipsSo.PurpleDamage;
            HealthValue = new Health(StatsShipsSo.PurpleHealth);
            _moveSpeed = Random.Range(StatsShipsSo.PurpleMinSpeed, StatsShipsSo.PurpleMaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
    }
}
