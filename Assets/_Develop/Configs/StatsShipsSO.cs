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
            public float Health;
            public float Damage;
            public float MinSpeed;
            public float MaxSpeed;
            public float FireRate;
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
