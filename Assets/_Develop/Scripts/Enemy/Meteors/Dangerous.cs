using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Dangerous : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            Damage = Stats.DangerousDamage;
            Health = new Health(Stats.DangerousHealth);

            Rb2D = GetComponent<Rigidbody2D>();
            Stats.DangerousSpeed = Random.Range(Stats.DangerousMinSpeed, Stats.DangerousMaxSpeed);
            Rb2D.velocity = Vector2.down * Stats.DangerousSpeed;
        }
    }
}
