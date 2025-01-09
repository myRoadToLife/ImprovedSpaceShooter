using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Enemy
    {
        [SerializeField] private float _rotateSpeed;

        private float _moveSpeed;
        
        public override void OnBecameInvisible() => Destroy(gameObject);
        
        public override void Initialize()
        {
            Damage = StatsMeteorSo.TerribleDamage;
            HealthValue = new Health(StatsMeteorSo.TerribleHealth);
            _moveSpeed = Random.Range(StatsMeteorSo.TerribleMinSpeed, StatsMeteorSo.TerribleMaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
    }
}
