using System;
using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Meteor
    {
        private void Update() => transform.Translate(0, -1 * Stats.TerribleSpeed * Time.deltaTime, 0);

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize(Stats stats)
        {
            Damage = Stats.TerribleDamage;
            Health = new Health(Stats.TerribleHealth);
            Stats.TerribleSpeed = Random.Range(Stats.TerribleMinSpeed, Stats.TerribleMaxSpeed);
        }
    }
}
