using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Plataform
{
    public class Plataform_Rotate_Final : MonoBehaviour
    {
        #region Variaveis
        [Header("Configurações da Plataforma")]
        [SerializeField] private float _rotationSpeed = 20f;
        [SerializeField] private float _acceleration = 1f;
        [SerializeField] private float _maxSpeed = 50f;

        [Header("Física de Inércia")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.3f;

        private Rigidbody _rb;
        private Rigidbody _activePlayer;
        private Vector3 _lastCentrifugalDir;
        private float _currentPlatformSpeed;
        private bool _isPlayerFlying;
        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _currentPlatformSpeed = _rotationSpeed;
        }

        private void FixedUpdate()
        {
            RotatePlatform();
            HandleCentrifugalPhysics();
        }

        private void RotatePlatform()
        {
            _currentPlatformSpeed = Mathf.Min(_currentPlatformSpeed + Time.fixedDeltaTime * _acceleration, _maxSpeed);
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(0, _currentPlatformSpeed * Time.fixedDeltaTime, 0));
        }

        private void HandleCentrifugalPhysics()
        {
            if (_activePlayer == null) return;

            Vector3 moveVelocity = _lastCentrifugalDir * _currentPlatformSpeed;
            float yVel = _activePlayer.linearVelocity.y;
            _activePlayer.linearVelocity = new Vector3(moveVelocity.x, yVel, moveVelocity.z);

            if (!_isPlayerFlying)
            {
                Quaternion playerDeltaRotation = Quaternion.Euler(0, _currentPlatformSpeed * Time.fixedDeltaTime, 0);
                _activePlayer.MoveRotation(_activePlayer.rotation * playerDeltaRotation);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerInput>())
            {
                _activePlayer = collision.gameObject.GetComponent<Rigidbody>();
                _isPlayerFlying = false;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerInput>())
            {
                _isPlayerFlying = true;
            }
        }

        private void Update()
        {
            if (_activePlayer != null) // ver se tem player
            {
                //calcular direção de lançametno
                Vector3 dir = _activePlayer.position - transform.position;
                dir.y = 0;
                _lastCentrifugalDir = Vector3.Cross(dir, Vector3.up).normalized;
            }
        }

        private void CheckForLanding()
        {
            // Laser invisível para detectar o chão e parar a força
            if (Physics.Raycast(_activePlayer.position, Vector3.down, _groundCheckDistance, _groundLayer))
            {
                StopCentrifugalForce();
            }
        }

        private void StopCentrifugalForce()
        {
            Debug.Log("Força centrifuga parada!");
            _isPlayerFlying = false;
            _activePlayer = null;
            _currentPlatformSpeed = _rotationSpeed;
        }
    }
}