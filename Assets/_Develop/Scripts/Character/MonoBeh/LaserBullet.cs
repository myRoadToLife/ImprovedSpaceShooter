using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character.MonoBeh
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LaserBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb2D;
        
        private LaserBulletSO _config;
        
        [Inject] private void Construct(LaserBulletSO config)
        {
            _config = config;
        }

        private void Start()
        {
            _rb2D.velocity = Vector2.up * _config.Speed;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy.Enemy enemy = collision.GetComponent<Enemy.Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(_config.Damage);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
