using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            _damage = _stats.WeakDamage;
            _health = new Health(_stats.WeakHealth);

            _rb2D = GetComponent<Rigidbody2D>();
            _stats.WeakSpeed = Random.Range(_stats.WeakMinSpeed, _stats.WeakMaxSpeed);
            _rb2D.velocity = Vector2.down * _stats.WeakSpeed;
        }
    }
}
