using _Develop.Scripts.Common;
using UnityEngine;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Meteor
    {
        [SerializeField]private int _rotateSpeed;
        
        private float _moveSpeed;
        
        private void Update() => MoveAndRotate();
        
        public override void OnBecameInvisible() => Destroy(gameObject);
        
        protected override void Initialize()
        {
            Damage = StatsMeteorSo.WeakDamage;
            HealthValue = new Health(StatsMeteorSo.WeakHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.WeakMinSpeed, StatsMeteorSo.WeakMaxSpeed);
        }
        
        private void MoveAndRotate()
        {
            transform.position += Vector3.down * (_moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
}
