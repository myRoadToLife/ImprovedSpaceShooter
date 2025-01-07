using System;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.VFX
{
    public class Explosion : MonoBehaviour
    {
        private Vector3 _position;
        private Quaternion _rotation;

        private readonly float _timeLife = 0.8f;

        [Inject] public void Construct(Vector3 position, Quaternion rotation)
        {
            _position = position;
            _rotation = rotation;
            transform.position = _position;
            transform.rotation = _rotation;

            Destroy(gameObject, _timeLife);
        }
    }
}
