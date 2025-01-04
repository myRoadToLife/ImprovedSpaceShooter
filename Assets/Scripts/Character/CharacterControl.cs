using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Character
{
    public class CharacterControl : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _offsetPosition;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            if (Touch.fingers[0].isActive == false)
                return;

            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPosition = myTouch.screenPosition;
            touchPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

            switch (Touch.activeTouches[0].phase)
            {
                case TouchPhase.Began:
                    _offsetPosition = touchPosition - transform.position;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    transform.position = new Vector3(touchPosition.x - _offsetPosition.x, touchPosition.y - _offsetPosition.y, 0);
                    break;
            }
        }

        private void OnEnable() => EnhancedTouchSupport.Enable();

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }
}
