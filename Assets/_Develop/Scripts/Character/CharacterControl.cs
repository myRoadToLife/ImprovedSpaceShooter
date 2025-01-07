using System.Collections;
using _Develop.Scripts.Configs;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace _Develop.Scripts.Character
{
    public class CharacterControl : MonoBehaviour, ICharacter
    {
        private MoveLimitSO _moveLimitSo;
        private Camera _mainCamera;
        private Vector3 _offsetPosition;
        private Coroutine _setBorders;
        
        [Inject] public void Construct(MoveLimitSO moveLimitSo, Camera mainCamera)
        {
            _moveLimitSo = moveLimitSo;
            _mainCamera = mainCamera;
            
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
                            _moveLimitSo.GetMaxLeft(), _moveLimitSo.GetMaxRight()),
                        Mathf.Clamp(transform.position.y,
                            _moveLimitSo.GetMaxDown(), _moveLimitSo.GetMaxUp()), 0);

                    break;
            }
        }

        private IEnumerator SetBorders()
        {
            yield return new WaitForSeconds(0.5f);
            _moveLimitSo.Initialize(_mainCamera);
        }

        private void OnEnable() => EnhancedTouchSupport.Enable();

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }
}
