using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Meteor
    {
        [SerializeField] private float _rotateSpeed;

        private float _moveSpeed;

        private void Update() => MoveAndRotate();

        public override void OnBecameInvisible() => Destroy(gameObject);
        
        protected override void Initialize()
        {
            Damage = StatsMeteorSo.TerribleDamage;
            HealthValue = new Health(StatsMeteorSo.TerribleHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.TerribleMinSpeed, StatsMeteorSo.TerribleMaxSpeed);
        }

        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (_moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
}
