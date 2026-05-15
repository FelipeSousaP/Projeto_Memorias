using Memorias.Gameplay.Player;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlataformRotate : MonoBehaviour
{
    #region Preparação e Configurações
    [Header("Rotate Settings")]
    public float _speedPlataform;
    public float _pushSpped;
    [HideInInspector] public bool _isCollided;

    [Header("Ejection Settings")]
    [Tooltip("Força vertical aplicada para fazer o jogador ou caixas pularem ao sair")]
    public float _upwardForce = 5f;

    [Tooltip("Tempo (em segundos) que o jogador perderá o controlo para poder voar")]
    public float _ejectionDuration = 0.3f;

    private Rigidbody _rb;
    private Quaternion quaternion;
    //Para calcular cada força de um objeto independentemente
    private Dictionary<Rigidbody, Vector3> _trackedObjects = new Dictionary<Rigidbody, Vector3>();
    #endregion
    private void Start() => _rb = GetComponent<Rigidbody>();
    private void FixedUpdate()
    {
        SetRotate();
        ApplyCentrifugeForceToAll();
    }

    #region Aplicar rotação na plataforma
    private void SetRotate()
    {
        quaternion = Quaternion.Euler(0, _speedPlataform * Time.fixedDeltaTime, 0);
        _rb.MoveRotation(_rb.rotation * quaternion);
    }
    #endregion

    private void ApplyCentrifugeForceToAll()
    {
        var keys = new List<Rigidbody>(_trackedObjects.Keys);
        foreach (Rigidbody objRb in keys)
        {
            if (objRb == null)
            {
                _trackedObjects.Remove(objRb);
                continue;
            }
            Vector3 dir = objRb.position - transform.position;
            Vector3 centrifugeDir = Vector3.Cross(dir, Vector3.up).normalized;
            _trackedObjects[objRb] = centrifugeDir;

            Vector3 movePlayer = centrifugeDir * _pushSpped;
            float Y = objRb.linearVelocity.y;
            objRb.linearVelocity = new Vector3(movePlayer.x, Y, movePlayer.z);

            Quaternion rotatePlayer = Quaternion.Euler(0, _pushSpped * Time.fixedDeltaTime, 0);
            objRb.MoveRotation(objRb.rotation * rotatePlayer);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody collidedRb = collision.gameObject.GetComponent<Rigidbody>();
        if (collidedRb != null && collidedRb != _rb)
        {
            if (!_trackedObjects.ContainsKey(collidedRb))
            {
                
                _trackedObjects.Add(collidedRb, Vector3.zero);

            }
            if(collision.gameObject.GetComponent<PlayerInput>() != null)
            {
                _isCollided = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody collidedRb = collision.gameObject.GetComponent<Rigidbody>();

        if (collidedRb != null && _trackedObjects.ContainsKey(collidedRb))
        {
            Vector3 lastDir = _trackedObjects[collidedRb];
            Vector3 ejectionForce = lastDir * _pushSpped;
            ejectionForce.y = _upwardForce;

            PlayerMove playerMovement = collision.gameObject.GetComponentInChildren<PlayerMove>();
            if (playerMovement != null)
            {
                playerMovement.EjectPlayer(ejectionForce, _ejectionDuration);
                _isCollided = false;
                Debug.Log("Jogador ejetado. Força: " + ejectionForce);
            }
            else
            {
                collidedRb.linearVelocity = new Vector3(ejectionForce.x, ejectionForce.y, ejectionForce.z);
                collidedRb.AddForce(ejectionForce, ForceMode.Impulse);
                Debug.Log("Objeto físico ejetado! Força: " + ejectionForce);
            }
            _trackedObjects.Remove(collidedRb);
        }
    }
}