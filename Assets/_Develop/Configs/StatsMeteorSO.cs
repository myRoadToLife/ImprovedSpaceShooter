using System;
using UnityEngine;

namespace _Develop.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Meteor/StatsMeteors", fileName = "StatsMeteors")]
    public class StatsMeteorSO : ScriptableObject
    {
        
        [SerializeField] private MeteorStats _weakMeteor = new MeteorStats();
        [SerializeField] private MeteorStats _dangerousMeteor = new MeteorStats();
        [SerializeField] private MeteorStats _terribleMeteor = new MeteorStats();
        
        public enum MeteorType
        {
            Weak,
            Dangerous,
            Terrible
        }

        [Serializable] public class MeteorStats
        {
            public float Health;
            public float Damage;
            public float MinSpeed;
            public float MaxSpeed;
        }

        public MeteorStats GetMeteorStats(MeteorType type)
        {
            switch (type)
            {
                case MeteorType.Weak:
                    return _weakMeteor;
                case MeteorType.Dangerous:
                    return _dangerousMeteor;
                case MeteorType.Terrible:
                    return _terribleMeteor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
