using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Character/CharacterStats", fileName = "CharacterStats")]
    public class CharacterStatsSO : ScriptableObject
    {
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float IntervalShoot { get; private set; } = 0.4f;
    }
}
