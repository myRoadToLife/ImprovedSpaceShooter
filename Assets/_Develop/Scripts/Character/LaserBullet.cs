using _Develop.Scripts.Configs;
using _Develop.Scripts.Enemy.Meteors;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class LaserBullet : MonoBehaviour
    {
        private LaserBulletSO _config;
        private Enemy.Enemy _enemy;

        [Inject] private void Construct(LaserBulletSO config)
        {
            _config = config;
        }

        private void Update()
        {
            transform.position += Vector3.up * (_config.Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy.Enemy enemy = collision.GetComponent<Enemy.Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(_config.Damage);
            }

            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
