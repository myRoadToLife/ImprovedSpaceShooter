using _Develop.Configs;
using _Develop.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Enemy.Meteors
{
    public class Terrible : Enemy
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private StatsMeteorSO _statsMeteor;
        
        private float _moveSpeed;
        
        public override void OnBecameInvisible() => Destroy(gameObject);
        
        public override void Initialize()
        {
            StatsMeteorSO.MeteorStats stats = _statsMeteor.GetMeteorStats(StatsMeteorSO.MeteorType.Terrible);
            
            Damage = stats.Damage;
            HealthValue = new Health(stats.Health);
            _moveSpeed = Random.Range(stats.MinSpeed, stats.MaxSpeed);
            Rb2D.velocity = Vector2.down * _moveSpeed;
        }
    }
}
