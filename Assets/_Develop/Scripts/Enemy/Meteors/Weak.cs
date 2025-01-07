using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        [SerializeField] private float _rotateSpeed;

        private void Update() => MoveAndRotate();

        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (Stats.WeakSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize(Stats stats)
        {
            Damage = Stats.WeakDamage;
            Health = new Health(Stats.WeakHealth);
            Stats.WeakSpeed = Random.Range(Stats.WeakMinSpeed, Stats.WeakMaxSpeed);
        }
    }
}
