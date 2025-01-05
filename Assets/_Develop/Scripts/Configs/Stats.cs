using UnityEngine;
using UnityEngine.Serialization;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Stats")]
    public class Stats : ScriptableObject
    {
        [Header("WeakMeteor")]
        public byte WeakHealth; 
        public byte WeakDamage;
        public float WeakSpeed { get; set; }
        public float WeakMaxSpeed;
        public float WeakMinSpeed;
        
        [Header("DangerousMeteor")]
        public byte DangerousHealth;
        public byte DangerousDamage;
        public float DangerousSpeed { get; set; }
        public float DangerousMaxSpeed;
        public float DangerousMinSpeed;
        
        [Header("TerribleMeteor")]
        public byte TerribleHealth;
        public byte TerribleDamage;
        public float TerribleSpeed { get; set; }
        public float TerribleMaxSpeed;
        public float TerribleMinSpeed;
    }
}
