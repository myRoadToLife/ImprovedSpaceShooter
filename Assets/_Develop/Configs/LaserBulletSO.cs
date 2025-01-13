using UnityEngine;

namespace _Develop.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Bullet/LaserBullet", fileName = "LaserBulletStats")]
    public class LaserBulletSO : ScriptableObject
    {
        [field: SerializeField, Range(0f, 10f)] public float Damage { get; private set; }
        [field: SerializeField, Range(0f, 20f)] public float Speed { get; private set; }
    }
}
