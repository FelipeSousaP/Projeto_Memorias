using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    public class PlayerJump: MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Jump Settings")]
        [SerializeField] private InputActionReference _jumpAction;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Transform _player;
        [SerializeField] private bool _isJumping;

        [Header("RayCast Settings")]
        [SerializeField] private float _distanceRay;
        [SerializeField] private LayerMask _layerMask;
        #endregion

        float _velocity;
        #region Etapa 2: input por evento
        private void OnEnable()
        {
            if (_jumpAction != null)
            {
                _jumpAction.action.performed += JumpPerfomed;
                _jumpAction.action.canceled += JumpPerfomed;
            }
        }
        private void OnDisable()
        {
            _jumpAction.action.performed -= JumpPerfomed;
            _jumpAction.action.canceled -= JumpPerfomed;
        }
        public void JumpPerfomed(InputAction.CallbackContext callbackContext)
        {
            _isJumping = callbackContext.ReadValueAsButton();
            _velocity = _jumpForce;
        }
        #endregion

        //caso esteja no sol, ele pode pular
        private void Update()
        {
            if (IsGrounded())
            {
                if (_isJumping) 
                {
                    _player.transform.position = new Vector3(0,_velocity,0) * Time.deltaTime;
                    Debug.Log("Ele pulo EBBAAAA");
                }
            }
        }

        private bool IsGrounded()
        {
            Vector3 end = Vector3.down * _distanceRay;
            Debug.DrawLine(_player.transform.position, end,Color.red);
            return Physics.Raycast(_player.transform.position, -transform.up, _distanceRay, _layerMask);
        }
    }
}