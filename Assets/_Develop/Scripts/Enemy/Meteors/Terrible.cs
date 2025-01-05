using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Meteor
    {
        protected override void Initialize(Stats stats)
        {
            Damage = Stats.TerribleDamage;
            Health = new Health(Stats.TerribleHealth);

            Rb2D = GetComponent<Rigidbody2D>();
            Stats.TerribleSpeed = Random.Range(Stats.TerribleMinSpeed, Stats.TerribleMaxSpeed);
            Rb2D.velocity = Vector2.down * Stats.TerribleSpeed;
        }
    }
}
