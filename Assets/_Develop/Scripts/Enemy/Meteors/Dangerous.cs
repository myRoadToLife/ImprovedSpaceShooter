using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Dangerous : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            _damage = _stats.DangerousDamage;
            _health = new Health(_stats.DangerousHealth);

            _rb2D = GetComponent<Rigidbody2D>();
            _stats.DangerousSpeed = Random.Range(_stats.DangerousMinSpeed, _stats.DangerousMaxSpeed);
            _rb2D.velocity = Vector2.down * _stats.DangerousSpeed;
        }
    }
}
