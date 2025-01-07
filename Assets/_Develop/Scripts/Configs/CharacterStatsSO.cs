using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/CharacterStats")]

    public class CharacterStatsSO : ScriptableObject
    {
        [field: SerializeField] public byte Health { get; private set; }
    }
}
