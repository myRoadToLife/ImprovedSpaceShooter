using System;
using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Dangerous : Meteor
    {
        private void Update() => transform.Translate(0, -1 * Stats.DangerousSpeed * Time.deltaTime, 0);

        public override void OnBecameInvisible() => Destroy(gameObject);
        
        protected override void Initialize(Stats stats)
        {
            Damage = Stats.DangerousDamage;
            Health = new Health(Stats.DangerousHealth);
            Stats.DangerousSpeed = Random.Range(Stats.DangerousMinSpeed, Stats.DangerousMaxSpeed);
        }
    }
}
