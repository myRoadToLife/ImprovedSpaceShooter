using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/RestrictionMovement")]
    public class MoveLimit : ScriptableObject
    {
        public float MaxLeft;
        public float MaxRight;
        public float MaxDown;
        public float MaxUp;

        private float _maxLeft;
        private float _maxRight;
        private float _maxDown;
        private float _maxUp;

        public void Initialize(Camera mainCam)
        {
            mainCam = Camera.main;
            _maxLeft = mainCam.ViewportToWorldPoint(new Vector2(MaxLeft, 0)).x;
            _maxRight = mainCam.ViewportToWorldPoint(new Vector2(MaxRight, 0)).x;
            _maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, MaxDown)).y;
            _maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, MaxUp)).y;
        }

        public float GetMaxLeft()
        {
            return _maxLeft;
        }

        public float GetMaxRight()
        {
            return _maxRight;
        }

        public float GetMaxDown()
        {
            return _maxDown;
        }

        public float GetMaxUp()
        {
            return _maxUp;
        }
    }
}
