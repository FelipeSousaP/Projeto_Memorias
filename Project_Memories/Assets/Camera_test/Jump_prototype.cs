using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump_prototype : MonoBehaviour
{
    [SerializeField] InputActionReference JumpAction;
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] float TempoPraPular;
    [SerializeField] float timer;
    [SerializeField] bool IsJumping;

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

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        IsJumping = callbackContext.action.IsPressed();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (IsJumping && timer >= TempoPraPular) //Não da pra usar == pois o numero é quebrado
        {
            rb.AddForce(Vector3.up * Speed,ForceMode.Impulse);
            timer = 0;
        }
    }
}
