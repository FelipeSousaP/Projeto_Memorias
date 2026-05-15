using Memorias.Gameplay.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlataformRotate : MonoBehaviour
{
    #region Preparação
    [Header("Rotate Settings")]
    public float _speedPlataform;
    [HideInInspector] public bool _isCollided;

    [Header("Ejection Settings")]
    [Tooltip("Força vertical aplicada para fazer o jogador pular ao sair")]
    public float _upwardForce = 5f;
    [Tooltip("Tempo (em segundos) que o jogador perderá o controlo para poder voar")]
    public float _ejectionDuration = 0.3f;

    private Rigidbody _rbObject;
    private Rigidbody _rb;
    private Quaternion quaternion;
    private Vector3 _lastCentrifuge;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    #endregion

    private void FixedUpdate()
    {
        SetRotate();
        if (_isCollided)
        {
            ApplyCentrifugeForce();
        }
    }

    #region Aplicar rotação na plataforma
    private void SetRotate()
    {
        quaternion = Quaternion.Euler(0, _speedPlataform * Time.fixedDeltaTime, 0); // de
        _rb.MoveRotation(_rb.rotation * quaternion);
    }
    #endregion


    private void ApplyCentrifugeForce()
    {
        if (_rbObject == null) return;
        //direção
        Vector3 dir = _rbObject.position - transform.position;
        _lastCentrifuge = Vector3.Cross(dir, Vector3.up).normalized;

        //calcular a moviemntação atual do player
        Vector3 movePlayer = _lastCentrifuge * _speedPlataform;
        float Y = _rbObject.linearVelocity.y;
        _rbObject.linearVelocity = new Vector3(movePlayer.x, Y, movePlayer.z);    

        //Aplicar rotaçaõ
        Quaternion RotatePlayer = Quaternion.Euler(0, _speedPlataform * Time.fixedDeltaTime, 0);   //calcular a rotação
        _rbObject.MoveRotation(_rbObject.rotation * RotatePlayer);    //Aplicar a rotação na fisica
        Debug.Log("Colidiu");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput>())
        {
            _rbObject = collision.gameObject.GetComponent<Rigidbody>();
            _isCollided = true;
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.GetComponent<PlayerInput>())
        {
            PlayerMove playerMovement = collision.gameObject.GetComponentInChildren<PlayerMove>();

            if (playerMovement != null)
            {
                Vector3 ejectionForce = _lastCentrifuge * _speedPlataform;
                ejectionForce.y = _upwardForce;
                playerMovement.EjectPlayer(ejectionForce, _ejectionDuration);
                Debug.Log("Jogador ejetado com sucesso! Força: " + ejectionForce);
            }

            _isCollided = false;
            _rbObject = null;
        }
    }
}

   
