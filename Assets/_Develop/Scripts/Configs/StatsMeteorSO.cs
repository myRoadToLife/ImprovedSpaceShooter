using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Meteor/StatsMeteors", fileName = "StatsMeteors")]
    public class StatsMeteorSO : ScriptableObject
    {
        [field: Header("WeakMeteor")]
        [field: SerializeField] public float WeakHealth{get; private set;} 
        [field: SerializeField] public float WeakDamage{get; private set;}
        [field: SerializeField] public float WeakMaxSpeed{get; private set;}
        [field: SerializeField] public float WeakMinSpeed{get; private set;}
        
        [field: Header("DangerousMeteor")]
        [field: SerializeField] public float DangerousHealth{get; private set;}
        [field: SerializeField] public float DangerousDamage{get; private set;}
        [field: SerializeField] public float DangerousMaxSpeed{get; private set;}
        [field: SerializeField] public float DangerousMinSpeed{get; private set;}
        
        [field: Header("TerribleMeteor")]
        [field: SerializeField] public float TerribleHealth{get; private set;}
        [field: SerializeField] public float TerribleDamage{get; private set;}
        [field: SerializeField] public float TerribleMaxSpeed{get; private set;}
        [field: SerializeField] public float TerribleMinSpeed{get; private set;}
    }
}
