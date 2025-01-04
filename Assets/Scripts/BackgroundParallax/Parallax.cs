using System;
using UnityEngine;

namespace BackgroundParallax
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _speedMove;

        private float _spriteHeight;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
            _spriteHeight = _spriteRenderer.bounds.size.y;
        }

        private void Update()
        {
            transform.Translate(Vector3.down * (_speedMove * Time.deltaTime));

            if (transform.position.y < _startPosition.y - _spriteHeight)
                transform.position = _startPosition;
        }
    }
}
