using UnityEngine;
using UnityEngine.InputSystem;

public class Jump_prototype : MonoBehaviour
{
    [SerializeField] InputActionReference JumpAction;
    [SerializeField] float JumpForce;

    Rigidbody body;
    private void Start() { body = GetComponent<Rigidbody>(); }

    #region Ativação dos imputs por Eventos
    private void OnEnable()
    {
        if (JumpAction != null)
        {
            JumpAction.action.performed += Jump;
            JumpAction.action.canceled += Jump;
        }    
    }
    private void OnDisable()
    {
        JumpAction.action.performed -= Jump;
        JumpAction.action.canceled -= Jump;
    }
    #endregion

    public void Jump(InputAction.CallbackContext callback)
    {
        body.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
        Debug.Log("ativado");
    }

    // detectar o chão
    //pular
}
