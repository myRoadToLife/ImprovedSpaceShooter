using System.Collections;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Character
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private LaserBullet _laserBulletPrefab;
        [SerializeField] private Transform _basicShootingPoint;

        [SerializeField] private float _intervalShoot;

        private bool _isCanShoot = true;
        [Inject] private DiContainer _container;

        private void Start()
        {
            StartCoroutine(IntervalShooting());
        }

        IEnumerator IntervalShooting()
        {
            while (_isCanShoot)
            {
                yield return new WaitForSeconds(_intervalShoot);

                Shoot();
            }
        }

        private void Shoot()
        {
            _container.InstantiatePrefab(_laserBulletPrefab, _basicShootingPoint.position, Quaternion.identity, null);
        }
    }
}
