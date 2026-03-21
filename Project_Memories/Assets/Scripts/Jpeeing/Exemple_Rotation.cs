using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Exemple_Rotation : MonoBehaviour{

    #region Variaveis
    //Conteudo serializado
    [SerializeField] private float speed;

    //Conteudo privado
    private Rigidbody _rb;
    private Rigidbody _playerRb;
    private Vector3 _dir;
    private Vector3 _velocity;

    #endregion

    #region Metodos

    //Metodos de inicializacao da Unity
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        SetVelocity();
        RotatePlayer();
    }

    //Calculos de fisica

    private void SetVelocity() {
        _rb.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }

    private void RotatePlayer() { 
        if (_playerRb != null) { 
            _dir = _playerRb.position - transform.position; 
            Vector3 tangential = Vector3.Cross(_dir, Vector3.up).normalized; 
            _playerRb.AddForce(tangential * speed, ForceMode.Impulse); 
            speed += Time.deltaTime * 0.5f; 
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerInput>()){
            _playerRb = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerInput>()) {
            _playerRb = null;
        }
    }

    #endregion

}
