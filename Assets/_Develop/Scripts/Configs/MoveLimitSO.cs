using UnityEngine;

namespace _Develop.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScriptableObject/RestrictionMovement")]
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
            mainCam = Camera.main;
            
            _maxLeft = mainCam.ViewportToWorldPoint(new Vector2(_maxLeftValue, 0)).x;
            _maxRight = mainCam.ViewportToWorldPoint(new Vector2(_maxRightValue, 0)).x;
            _maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, _maxDownValue)).y;
            _maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, _maxUpValue)).y;
        }

        public float GetMaxLeft() => _maxLeft;

        public float GetMaxRight() => _maxRight;

        public float GetMaxDown() => _maxDown;

        public float GetMaxUp() => _maxUp;
    }
}
