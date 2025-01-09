using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Common
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [Header("Meteors")] [SerializeField] private Enemy.Enemy[] _meteorsPrefabs;
        [SerializeField] private float _timeSpawnMeteor = 1.5f;

        [Header("Ships")] [SerializeField] private Enemy.Enemy[] _shipsPrefabs;
        [SerializeField] private float _timeSpawnShips = 2f;

        private DiContainer _container;
        private Camera _camera;

        private float _maxLeftPosX;
        private float _maxRightPosX;
        private float _maxPosY;

        private bool _isSpawning = true;

        [Inject] public void Construct(DiContainer container, Camera camera)
        {
            _container = container;
            _camera = camera;

            StartCoroutine(SetBorders());
            StartCoroutine(SpawnMeteors());
        }

        IEnumerator SpawnMeteors()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(_timeSpawnMeteor);
                Enemy.Enemy meteor = MeteorSetSpawn(out Vector3 meteorPos, out Quaternion meteorRot);
                _container.InstantiatePrefab(meteor, meteorPos, meteorRot, null);

                yield return new WaitForSeconds(_timeSpawnShips);
                Enemy.Enemy ship = ShipSetSpawn(out Vector3 shipPos, out Quaternion shipRot);
                _container.InstantiatePrefab(ship, shipPos, shipRot, null);
            }
        }

        private Enemy.Enemy MeteorSetSpawn(out Vector3 position, out Quaternion meteorRot)
        {
            Enemy.Enemy meteor = _meteorsPrefabs[Random.Range(0, _meteorsPrefabs.Length)];
            position = new Vector3(Random.Range(_maxLeftPosX, _maxRightPosX), _maxPosY, -5);
            meteorRot = Quaternion.identity;
            return meteor;
        }

        private Enemy.Enemy ShipSetSpawn(out Vector3 position, out Quaternion shipRot)
        {
            Enemy.Enemy ship = _shipsPrefabs[Random.Range(0, _shipsPrefabs.Length)];
            position = new Vector3(Random.Range(_maxLeftPosX, _maxRightPosX), _maxPosY, -5);
            shipRot = Quaternion.identity;
            return ship;
        }

        private IEnumerator SetBorders()
        {
            yield return new WaitForEndOfFrame();

            _maxLeftPosX = _camera.ViewportToWorldPoint(new Vector2(0.05f, 0)).x;
            _maxRightPosX = _camera.ViewportToWorldPoint(new Vector2(0.95f, 0)).x;
            _maxPosY = _camera.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
        }
    }
}
