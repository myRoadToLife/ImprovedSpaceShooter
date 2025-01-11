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
        private MoveLimitSO _moveLimitSo;
        private Camera _mainCamera;
        private Vector2 _targetPosition;
        CharacterStatsSO _stats;
        private bool _isMoving;
        
        [Inject] public void Construct(MoveLimitSO moveLimitSo, Camera mainCamera, CharacterStatsSO stats)
        {
            _moveLimitSo = moveLimitSo;
            _mainCamera = mainCamera;
            _stats = stats;

            StartCoroutine(SetBorders());
        }

        private void Update()
        {
            HandleTouchInput();
            MoveTowardsTarget();
        }

        private void HandleTouchInput()
        {
            if (Touch.activeTouches.Count == 0)
                return;

            Touch touch = Touch.activeTouches[0];

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(touch.screenPosition);
                touchPosition.z = 0;

                _targetPosition = new Vector2(
                    Mathf.Clamp(touchPosition.x, _moveLimitSo.MaxLeft, _moveLimitSo.MaxRight),
                    Mathf.Clamp(touchPosition.y, _moveLimitSo.MaxDown, _moveLimitSo.MaxUp)
                );

                _isMoving = true;
            }
        }

        private void MoveTowardsTarget()
        {
            if (!_isMoving)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _stats.MoveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _targetPosition) < 0.01f)
            {
                transform.position = _targetPosition;
                _isMoving = false;
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
