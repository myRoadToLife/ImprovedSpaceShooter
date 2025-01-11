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
        [SerializeField] private float _timeSpawnShips = 1f;

        private DiContainer _container;
        private Camera _camera;

        private Coroutine _spawnEnemies;
        private Coroutine _setBorders;

        private float _maxLeftPosX;
        private float _maxRightPosX;
        private float _maxPosY;
        
        [Inject] public void Construct(DiContainer container, Camera camera)
        {
            _container = container;
            _camera = camera;

            _setBorders = StartCoroutine(SetBorders());
            _spawnEnemies = StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeSpawnMeteor);
                Enemy.Enemy meteor = SetSpawn(_meteorsPrefabs, out Vector3 meteorPos, out Quaternion meteorRot);
                _container.InstantiatePrefab(meteor, meteorPos, meteorRot, null);

                yield return new WaitForSeconds(_timeSpawnShips);
                Enemy.Enemy ship = SetSpawn(_shipsPrefabs, out Vector3 shipPos, out Quaternion shipRot);
                _container.InstantiatePrefab(ship, shipPos, shipRot, null);
            }
        }

        private Enemy.Enemy SetSpawn(Enemy.Enemy[] prefabs, out Vector3 position, out Quaternion rotation)
        {
            Enemy.Enemy enemy = prefabs[Random.Range(0, prefabs.Length)];
            position = new Vector3(Random.Range(_maxLeftPosX, _maxRightPosX), _maxPosY, -5);
            rotation = (enemy == _meteorsPrefabs[0]) ? transform.rotation : Quaternion.identity;
            return enemy;
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
