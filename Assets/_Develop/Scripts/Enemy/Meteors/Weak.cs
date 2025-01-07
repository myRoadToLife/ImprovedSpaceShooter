using _Develop.Scripts.Common;
using _Develop.Scripts.Configs;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        [SerializeField]private int _rotateSpeed;
        private float _moveSpeed;
        
        private void Update() => MoveAndRotate();

        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (_moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }

        public override void OnBecameInvisible() => Destroy(gameObject);

        protected override void Initialize(StatsMeteorSO statsMeteorSo)
        {
            Damage = StatsMeteorSo.WeakDamage;
            Health = new Health(StatsMeteorSo.WeakHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.WeakMinSpeed, StatsMeteorSo.WeakMaxSpeed);
        }
    }
}
