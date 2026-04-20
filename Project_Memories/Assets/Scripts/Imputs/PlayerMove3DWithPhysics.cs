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
        private bool _isRunning;
        #endregion 

        #region Etapa 2: Input do jogador
        private void OnEnable()
        {
            if (_moveAction != null) 
            {
                _moveAction.action.performed += MoveCalculated;
                _moveAction.action.canceled += MoveCanceled;
            }
        }
        private void OnDisable()
        {
            _moveAction.action.performed -= MoveCalculated;
            _moveAction.action.canceled -= MoveCanceled;
        }
        public void MoveCalculated(InputAction.CallbackContext c)
        {
            _value = c.ReadValue<Vector2>();
            _isRunning = true;
            _walkAnimation.SetBool(_animationName,_isRunning);
        }
        public void MoveCanceled(InputAction.CallbackContext c) {
            _value = Vector2.zero; 
            _isRunning = false;
            _walkAnimation.SetBool(_animationName,_isRunning);
        }
        #endregion

        #region Etapa 3 Ações
        private void Update()
        {
            Vector3 valueNormalized = new Vector3(_value.x, 0, _value.y).normalized;
            //transform.rotation = Quaternion.LookRotation(valueNormalized);// rotaciona pra direção que o value indica
            if (_isRunning) 
            {
                _player.rotation = Quaternion.LookRotation(valueNormalized); // Precisa ser trocado para uma animação da personagem rotacionando
                _rigidBody.linearVelocity = new Vector3(valueNormalized.x * _speedMove, _rigidBody.linearVelocity.y, valueNormalized.z * _speedMove);
            }
        }
        #endregion
    }
}