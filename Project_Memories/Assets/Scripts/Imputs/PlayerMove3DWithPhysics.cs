using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    public class PlayerMove3DWithPhysics: MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Input Settings")]
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private Transform _player;

        [Header("Physics Settings")]
        [SerializeField] private float _speedMove;
        [SerializeField] private Rigidbody _rigidBody;

        [Header("Animator Settings")]
        [SerializeField] private Animator _walkAnimation;
        [SerializeField] private string _animationName;

        private Vector2 _value;
        #endregion 

        #region Etapa 2: Input do jogador
        private void OnEnable()
        {
            if (_moveAction != null) 
            {
                _moveAction.action.performed += MovePerformed;
                _moveAction.action.canceled += MoveCanceled;
            }
        }
        private void OnDisable()
        {
            _moveAction.action.performed -= MovePerformed;
            _moveAction.action.canceled -= MoveCanceled;
        }
        public void MovePerformed(InputAction.CallbackContext c)
        {
            _value = c.ReadValue<Vector2>();
        }
        public void MoveCanceled(InputAction.CallbackContext c) => _value = Vector2.zero;
        #endregion

        #region Etapa 3 Ações
        private void Update()
        {
            Transform newRotate = _player;
            Vector3 valueNormalized = new Vector3(_value.x, 0, _value.y).normalized;
            //transform.rotation = Quaternion.LookRotation(valueNormalized);// rotaciona pra direção que o value indica
            if (valueNormalized != null)
            {
                newRotate.rotation = Quaternion.LookRotation(valueNormalized);
                AnimatorManager.Instance.CurrentAnimation(_walkAnimation, _animationName);
                _rigidBody.linearVelocity = new Vector3(valueNormalized.x * _speedMove, _rigidBody.linearVelocity.y, valueNormalized.z * _speedMove);
            }
            _player.rotation = newRotate.rotation;
        }
        #endregion
    }
}