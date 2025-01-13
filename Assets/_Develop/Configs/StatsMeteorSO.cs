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
            [field: SerializeField, Range(0f, 10f)] public float Health { get; private set; }
            [field: SerializeField, Range(0f, 10f)] public float Damage { get; private set; }
            [field: SerializeField, Range(0f, 100f)] public float MinSpeed { get; private set; }
            [field: SerializeField, Range(0f, 100f)] public float MaxSpeed { get; private set; }

            public void Validate()
            {
                MaxSpeed = Mathf.Max(MaxSpeed, MinSpeed + 1f);
                MinSpeed = Mathf.Min(MinSpeed, MaxSpeed - 1f);
            }
        }

        private void OnValidate()
        {
            _weakMeteor.Validate();
            _dangerousMeteor.Validate();
            _terribleMeteor.Validate();
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
