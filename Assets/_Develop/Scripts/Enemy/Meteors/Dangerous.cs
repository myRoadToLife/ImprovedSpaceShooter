using System;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Dangerous : Meteor
    {
        [SerializeField] private float _rotateSpeed;

        private float _moveSpeed;
        private void Update() => MoveAndRotate();

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize()
        {
            Damage = StatsMeteorSo.DangerousDamage;
            HealthValue = new Health(StatsMeteorSo.DangerousHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.DangerousMinSpeed, StatsMeteorSo.DangerousMaxSpeed);
        }

        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (_moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
}
