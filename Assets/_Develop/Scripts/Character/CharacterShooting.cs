using System.Collections;
using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private LaserBullet _laserBulletPrefab;
        [SerializeField] private Transform _basicShootingPoint;

        private CharacterStatsSO _stats;
        private DiContainer _container;
        private bool _isCanShoot = true;

        [Inject] public void Construct(DiContainer container, CharacterStatsSO stats)
        {
            _container = container;
            _stats = stats;
            
            StartCoroutine(IntervalShooting());
        }

        IEnumerator IntervalShooting()
        {
            while (_isCanShoot)
            {
                yield return new WaitForSeconds(_stats.IntervalShoot);
                
                Shoot();
            }
        }

        private void Shoot()
        {
            _container.InstantiatePrefab(_laserBulletPrefab, _basicShootingPoint.position, Quaternion.identity, null);
        }
    }
}
