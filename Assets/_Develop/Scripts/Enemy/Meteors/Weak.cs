using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        private void Update() => transform.Translate(0, -1 * Stats.WeakSpeed * Time.deltaTime, 0);

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize(Stats stats)
        {
            Damage = Stats.WeakDamage;
            Health = new Health(Stats.WeakHealth);
            Stats.WeakSpeed = Random.Range(Stats.WeakMinSpeed, Stats.WeakMaxSpeed);
        }
    }
}
