using UnityEngine;

namespace _Develop.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Character/CharacterStats", fileName = "CharacterStats")]
    public class CharacterStatsSO : ScriptableObject
    {
        [field: SerializeField, Range(0f, 100f)] public float Health { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float MoveSpeed { get; private set; }
        
        [field: SerializeField, Range(0f, 1f)] public float IntervalShoot { get; private set; } = 0.4f;
    }
}
