using System;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Weak : Enemy
    {
        [SerializeField]private int _rotateSpeed;
        
        private float _moveSpeed;
        
        public override void OnBecameInvisible() => Destroy(gameObject);
        
        public override void Initialize()
        {
            Damage = StatsMeteorSo.WeakDamage;
            HealthValue = new Health(StatsMeteorSo.WeakHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.WeakMinSpeed, StatsMeteorSo.WeakMaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
        
    }
}
