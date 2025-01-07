using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Stats")]
    public class StatsMeteorSO : ScriptableObject
    {
        [field: Header("WeakMeteor")]
        [field: SerializeField] public byte WeakHealth{get; private set;} 
        [field: SerializeField] public byte WeakDamage{get; private set;}
        [field: SerializeField] public float WeakMaxSpeed{get; private set;}
        [field: SerializeField] public float WeakMinSpeed{get; private set;}
        
        [field: Header("DangerousMeteor")]
        [field: SerializeField] public byte DangerousHealth{get; private set;}
        [field: SerializeField] public byte DangerousDamage{get; private set;}
        [field: SerializeField] public float DangerousMaxSpeed{get; private set;}
        [field: SerializeField] public float DangerousMinSpeed{get; private set;}
        
        [field: Header("TerribleMeteor")]
        [field: SerializeField] public byte TerribleHealth{get; private set;}
        [field: SerializeField] public byte TerribleDamage{get; private set;}
        [field: SerializeField] public float TerribleMaxSpeed{get; private set;}
        [field: SerializeField] public float TerribleMinSpeed{get; private set;}
    }
}
