using System.Collections;
using _Develop.Scripts.Enemy.Meteors;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Develop.Scripts.Common.Spawners
{
    public class SpawnerMeteors : MonoBehaviour
    {
        [SerializeField] private Meteor[] _meteorsPrefabs;
        [SerializeField] private float _timeForSpawn;

        [Inject] private DiContainer _container;

        private Camera _camera;
        private float _maxLeftPosX;
        private float _maxRightPosX;
        private float _maxPosY;

        private bool _isSpawning = true;

        private void Start()
        {
            _camera = Camera.main;
            
            StartCoroutine(SetBorders());
            StartCoroutine(SpawnMeteors());
        }

        IEnumerator SpawnMeteors()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(_timeForSpawn);

                Meteor meteor = _meteorsPrefabs[Random.Range(0, _meteorsPrefabs.Length)];
                Vector3 position = new Vector3(Random.Range(_maxLeftPosX, _maxRightPosX), _maxPosY, -5);
                Quaternion rotation = Quaternion.identity;

                _container.InstantiatePrefab(meteor, position, rotation, null);
            }
        }
        

        private IEnumerator SetBorders()
        {
            float timeForSet = 0.4f;
            
            yield return new WaitForSecondsRealtime(timeForSet);

            _maxLeftPosX = _camera.ViewportToWorldPoint(new Vector2(0.05f, 0)).x;
            _maxRightPosX = _camera.ViewportToWorldPoint(new Vector2(0.95f, 0)).x;
            _maxPosY = _camera.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
        }
    }
}