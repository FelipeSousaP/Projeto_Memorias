using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    public class PlayerMovement: MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Input Settings")]
        [SerializeField] private InputActionReference _moveAction;
        [Tooltip("Controla o a velocidade do seu movimento")]
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerTranform;

        [Header("Detector of Wall")]
        [SerializeField] private float _distanceRay;
        [SerializeField] private LayerMask _layer;
        
        private Vector2 _value;
        private Vector3 _finalMoviment;
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
        public void MovePerformed(InputAction.CallbackContext c) => _value = c.ReadValue<Vector2>();
        public void MoveCanceled(InputAction.CallbackContext c) => _value = Vector2.zero;
        #endregion
        #region Etapa 3 Ações
        private void Update()
        {
            // 1. Define a intenção de movimento
            _finalMoviment = new Vector3(_value.x, 0, _value.y);

            // condicional: so se move se tiver Input/ alteração no input
            if (_finalMoviment != Vector3.zero)
            {
                //condicional: _finalmoviment a direção que o jogador de move é gerado o raio
                if (!Physics.Raycast(_playerTranform.position, _finalMoviment.normalized, _distanceRay, _layer))
                {
                    _playerTranform.Translate(_finalMoviment * _speed * Time.deltaTime);
                    Debug.DrawRay(_playerTranform.position, _finalMoviment.normalized * _distanceRay, Color.green);
                }
                else
                {
                    Debug.DrawRay(_playerTranform.position, _finalMoviment.normalized * _distanceRay, Color.red);
                }
            }
        }
        #endregion
    }
}