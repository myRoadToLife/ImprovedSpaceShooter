using _Develop.Scripts.Character;
using UnityEngine;

namespace _Develop.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rb2D{get; private set;}
        [field: SerializeField] public float Damage { get; private set; }

        public abstract void OnTriggerEnter2D(Collider2D other);
        
        public abstract void OnBecameInvisible();

    }
}
