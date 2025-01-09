using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Ships/StatsShips", fileName = "StatsShips")]
    public class StatsShipsSO : ScriptableObject
    {
        [field: Header("PurpleShip")]
        [field: SerializeField] public float PurpleHealth{get; private set;} 
        [field: SerializeField] public float PurpleDamage{get; private set;}
        [field: SerializeField] public float PurpleMaxSpeed{get; private set;}
        [field: SerializeField] public float PurpleMinSpeed{get; private set;}
        [field: SerializeField] public float PurpleFireRate{get; private set;}
        
        [field: Header("GreenShip")]
        [field: SerializeField] public float GreenHealth{get; private set;} 
        [field: SerializeField] public float GreenDamage{get; private set;}
        [field: SerializeField] public float GreenMaxSpeed{get; private set;}
        [field: SerializeField] public float GreenMinSpeed{get; private set;}
    }
}
