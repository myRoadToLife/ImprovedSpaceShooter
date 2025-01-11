using UnityEngine;

namespace _Develop.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/CameraSettings/RestrictionMovement", fileName = "RestrictionMovementValue")]
    public class MoveLimitSO : ScriptableObject
    {
        [SerializeField] private float _maxLeftValue;
        [SerializeField] private float _maxRightValue;
        [SerializeField] private float _maxDownValue;
        [SerializeField] private float _maxUpValue;

        private float _maxLeft;
        private float _maxRight;
        private float _maxDown;
        private float _maxUp;

        public void Initialize(Camera mainCam)
        {
            Vector2 leftPoint = new Vector2(_maxLeftValue, 0);
            Vector2 rightPoint = new Vector2(_maxRightValue, 0);
            Vector2 downPoint = new Vector2(0, _maxDownValue);
            Vector2 upPoint = new Vector2(0, _maxUpValue);

            _maxLeft = mainCam.ViewportToWorldPoint(leftPoint).x;
            _maxRight = mainCam.ViewportToWorldPoint(rightPoint).x;
            _maxDown = mainCam.ViewportToWorldPoint(downPoint).y;
            _maxUp = mainCam.ViewportToWorldPoint(upPoint).y;
        }

        public float MaxLeft => _maxLeft;

        public float MaxRight => _maxRight;

        public float MaxDown => _maxDown;

        public float MaxUp => _maxUp;
    }
}
