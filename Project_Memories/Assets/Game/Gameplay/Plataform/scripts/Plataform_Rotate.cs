using Memorias.Gameplay.Player;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Plataform
{
    public class Plataform_Rotate : MonoBehaviour
    {

        #region Variaveis
        [Tooltip("Velocidade atual do")]
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration = 0.5f;
        [SerializeField] private float _maxSpeed = 20f;

        private float _initialSpeed;
        private Rigidbody _rb;
        private Rigidbody _playerRb;
        private Vector3 _dir;

        #endregion

        #region Metodos

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
        private void SetVelocity()
        {
            _rb.rotation *= Quaternion.Euler(0, _speed * Time.deltaTime, 0);
        }

        private void RotatePlayer()
        {
            if (_playerRb != null)
            {
                _dir = _playerRb.position - transform.position;
                
                Vector3 tangential = Vector3.Cross(_dir, Vector3.up).normalized;
                _playerRb.AddForce(tangential * _speed, ForceMode.Impulse);
                //O Mathf.Min compara dois "números" e escolhe sempre o menor deles para ser armazenada na variavel.
                _speed = Mathf.Min(_speed + Time.deltaTime * _acceleration, _maxSpeed);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerJump>())
            {
                _playerRb = collision.gameObject.GetComponent<Rigidbody>();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerJump>())
            {
                _playerRb = null;
                _speed = _initialSpeed;
            }
        }
        #endregion
    }
}


