using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    public class PlayerMove3DWithPhysics: MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Input Settings")]
        [SerializeField] private InputActionReference _moveAction;

        [Header("Physics Settings")]
        [SerializeField] private float _speedMove;
        [SerializeField] private Rigidbody _rigidBody;
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
            Vector3 valueNormalized = new Vector3(_value.x, 0, _value.y).normalized;
            _rigidBody.linearVelocity = new Vector3(valueNormalized.x * _speedMove, _rigidBody.linearVelocity.y, valueNormalized.z * _speedMove);
        }
        #endregion
    }
}