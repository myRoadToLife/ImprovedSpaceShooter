using _Develop.Scripts.Configs;
using _Develop.Scripts.Enemy.Meteors;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class LaserBullet : MonoBehaviour
    {
        private LaserBulletSO _config;
        private Meteor _meteor;

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
            Meteor meteor = collision.GetComponent<Meteor>();

            if (meteor != null)
            {
                meteor.TakeDamage(_config.Damage);
            }

            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
