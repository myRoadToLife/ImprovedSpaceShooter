using _Develop.Scripts.Character.MonoBeh;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Ships.Projectiles
{
    public class PurpleBullet : Bullet
    {
        [SerializeField] private float _speed;

        private void Start()
        {
            Rb2D.velocity = Vector2.down * _speed;
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();

            if (characterHealth != null)
            {
                characterHealth.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }

        public override void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
