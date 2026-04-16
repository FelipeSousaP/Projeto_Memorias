using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

namespace Memorias.Gameplay.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] InputActionReference JumpAction;
        [SerializeField] Rigidbody rb;
        [SerializeField] float Speed;
        [SerializeField] float TempoPraPular;
        [SerializeField] float timer;
        [SerializeField] bool IsJumping;
        [SerializeField] private VisualEffect _jumpParticles;

        private void OnEnable()
        {
            JumpAction.action.performed += Jump;
            JumpAction.action.canceled += Jump;
        }
        private void OnDisable()
        {
            JumpAction.action.performed -= Jump;
            JumpAction.action.canceled -= Jump;
        }
        public void Jump(InputAction.CallbackContext callbackContext)
        {
            IsJumping = callbackContext.action.IsPressed();

        }
        void Update()
        {
            timer += Time.deltaTime;
            if (IsJumping && timer >= TempoPraPular) //Não da pra usar == pois o numero é quebrado
            {
                rb.AddForce(Vector3.up * Speed, ForceMode.Impulse);
                timer = 0;
                _jumpParticles.SendEvent("OnJump");
            }

            if (!IsJumping) {
                _jumpParticles.SendEvent("OnStopJump");
            }
        }
    
    /*#region Etapa 1: Requisitos
        [Header("Input Settings")]
        [SerializeField] private InputActionReference _jumpAction;
        [SerializeField] private int _Quantospulospodedar = 0;
        [SerializeField] private int _Quantospulosdeu;

        [Header("Physics Settings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private Rigidbody _rb;

        [Header("RayCast Settings")]
        [SerializeField] private Transform _player;
        [SerializeField] private float _distanceRay;
        [SerializeField] private LayerMask _layerMask;

        #endregion

                    if (_jumpAction != null)
            {
                _jumpAction.action.performed += JumpPerfomed;
                _jumpAction.action.canceled += JumpPerfomed;
            }

          private void OnDisable()
      {
          _jumpAction.action.performed -= JumpPerfomed;
          _jumpAction.action.canceled -= JumpPerfomed;
      }
      public void JumpPerfomed(InputAction.CallbackContext callbackContext)
      {
          if (callbackContext.performed && callbackContext.ReadValueAsButton())
          {
              if (IsGrounded())
              {
                  _Quantospulosdeu = 0;
                  Debug.Log("No chão: Contador resetado.");
              }

              if (_Quantospulosdeu < _Quantospulospodedar)
              {
                  _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z); //Para resetar a velocidade causada pelos inputs do move + o Pulo
                  _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                  _Quantospulosdeu++;
                  Debug.Log($"Pulou! Total de pulos: {_Quantospulosdeu}");
                      }
                  }
              }
              #endregion
        private bool IsGrounded()
        {
          return Physics.Raycast(_player.position, Vector3.down, _distanceRay, _layerMask);
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
          if (_player == null) return;
          Gizmos.color = IsGrounded() ? Color.green : Color.red;
          Vector3 direction = Vector3.down * _distanceRay;
          Gizmos.DrawRay(_player.position, direction);
        }
        #endif
        }
        */
    }
}