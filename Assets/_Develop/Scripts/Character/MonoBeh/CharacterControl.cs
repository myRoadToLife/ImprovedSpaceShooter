using System.Collections;
using _Develop.Configs;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace _Develop.Scripts.Character.MonoBeh
{
    public class CharacterControl : MonoBehaviour
    {
        private MoveLimitSO _moveLimit;
        private Camera _mainCamera;
        private Vector3 _offsetPosition;
        private Coroutine _setBorders;
        
        [Inject] public void Construct(MoveLimitSO moveLimit)
        {
            _moveLimit = moveLimit;
        }
        
        private void Start()
        {
            _mainCamera = Camera.main;
            _moveLimit.Initialize(_mainCamera);
            _setBorders = StartCoroutine(SetBorders());
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
                    
                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x,
                            _moveLimit.MaxLeft, _moveLimit.MaxRight),
                        Mathf.Clamp(transform.position.y,
                            _moveLimit.MaxDown, _moveLimit.MaxUp), 0);
                    break;
            }
        }

        private IEnumerator SetBorders()
        {
            yield return new WaitForEndOfFrame();
            _moveLimit.Initialize(_mainCamera);
        }
        private void OnEnable() => EnhancedTouchSupport.Enable();

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }
}
