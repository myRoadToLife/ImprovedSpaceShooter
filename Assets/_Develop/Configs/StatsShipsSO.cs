using System;
using UnityEngine;

namespace _Develop.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/Ships/StatsShips", fileName = "StatsShips")]
    public class StatsShipsSO : ScriptableObject
    {
        [SerializeField] private ShipStat _purpleShip = new ShipStat();
        [SerializeField] private ShipStat _greenShip = new ShipStat();

        public enum ShipType
        {
            Purple,
            Green,
        }

        [Serializable] public class ShipStat
        {
            [field: SerializeField, Range(0f, 100f)]
            public float Health { get; private set; }

            [field: SerializeField, Range(0f, 100f)]
            public float Damage { get; private set; }

            [field: SerializeField, Range(0f, 100f)]
            public float MinSpeed { get; private set; }

            [field: SerializeField, Range(0f, 100f)]
            public float MaxSpeed { get; private set; }

            [field: SerializeField, Range(0f, 100f)]
            public float FireRate { get; private set; }

            public void Validate()
            {
                MaxSpeed = Mathf.Max(MaxSpeed, MinSpeed + 1f);
                MinSpeed = Mathf.Min(MinSpeed, MaxSpeed - 1f);
            }
        }

        private void OnValidate()
        {
            _purpleShip.Validate();
            _greenShip.Validate();
        }

        public ShipStat GetShipStats(ShipType type)
        {
            switch (type)
            {
                case ShipType.Purple:
                    return _purpleShip;
                case ShipType.Green:
                    return _greenShip;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
