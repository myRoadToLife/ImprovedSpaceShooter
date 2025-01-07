using System;
using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Meteor
    {
        [SerializeField] private float _rotateSpeed;

        private void Update() => MoveAndRotate();

        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (Stats.TerribleSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize(Stats stats)
        {
            Damage = Stats.TerribleDamage;
            Health = new Health(Stats.TerribleHealth);
            Stats.TerribleSpeed = Random.Range(Stats.TerribleMinSpeed, Stats.TerribleMaxSpeed);
        }
    }
}
