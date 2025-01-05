using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            _damage = _stats.TerribleDamage;
            _health = new Health(_stats.TerribleHealth);

            _rb2D = GetComponent<Rigidbody2D>();
            _stats.TerribleSpeed = Random.Range(_stats.TerribleMinSpeed, _stats.TerribleMaxSpeed);
            _rb2D.velocity = Vector2.down * _stats.TerribleSpeed;
        }
    }
}
