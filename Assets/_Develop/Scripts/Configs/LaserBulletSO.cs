using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/LaserBullet")]
    public class LaserBulletSO : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}
