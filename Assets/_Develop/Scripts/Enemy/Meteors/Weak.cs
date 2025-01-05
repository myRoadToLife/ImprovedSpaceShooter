using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            Damage = Stats.WeakDamage;
            Health = new Health(Stats.WeakHealth);

            Rb2D = GetComponent<Rigidbody2D>();
            Stats.WeakSpeed = Random.Range(Stats.WeakMinSpeed, Stats.WeakMaxSpeed);
            Rb2D.velocity = Vector2.down * Stats.WeakSpeed;
        }
    }
}
