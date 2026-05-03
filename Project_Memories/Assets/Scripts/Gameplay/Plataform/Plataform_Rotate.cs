using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Plataform
{
    public class Plataform_Rotate : MonoBehaviour
    {
        #region Variaveis
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration = 0.5f;
        [SerializeField] private float _maxSpeed = 20f;

        private float _initialSpeed;
        private Rigidbody _rb;
        private Rigidbody _playerRb;
        private Vector3 _dir;
        #endregion

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _initialSpeed = _speed;
        }

        private void FixedUpdate()
        {
            SetVelocity();
            RotatePlayer();
        }

        #region Etapa: Rotação
        private void SetVelocity()
        {
            _rb.rotation *= Quaternion.Euler(0, _speed * Time.fixedDeltaTime, 0);
        }
        #endregion
        #region Etapa: Detectar jogador
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerInput>())
            {
                Debug.Log("Eu to aqui");
                _playerRb = collision.gameObject.GetComponent<Rigidbody>();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerInput>())
            {
                _playerRb = null;
                _speed = _initialSpeed;
            }
        }
        #endregion

        private void RotatePlayer()
        {
            if (_playerRb != null)
            {
                // Criando a direção do centro do objeto até o jogador
                _dir = _playerRb.position - transform.position;
                _dir.y = 0;

                //Calculando a tangente pela direção do jogador
                Vector3 tangential = Vector3.Cross(_dir, Vector3.up).normalized;

                //definindo se a velocidade vai ser MAXIMA no inicio ou vai ficar aumentado até chegar proximo da velocidade MAXIMA
                _speed = Mathf.Min(_speed + Time.fixedDeltaTime * _acceleration, _maxSpeed);
                
                //Adiciona a força pro jogador ser jogador muito longe
                _playerRb.AddForce(tangential * _speed, ForceMode.Impulse);

                //add é furada
                Vector3 newVelocity = tangential * _speed;
                float yVelocity = _playerRb.linearVelocity.y;
                _playerRb.linearVelocity = new Vector3(newVelocity.x, yVelocity, newVelocity.z);
            }
        }
    }
}

