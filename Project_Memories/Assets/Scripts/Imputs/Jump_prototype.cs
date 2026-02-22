using UnityEngine;
using UnityEngine.InputSystem;

public class Jump_prototype : MonoBehaviour
{
    [SerializeField] InputActionReference JumpAction;
    [SerializeField] float Speed;
    [SerializeField] bool Isjumping;
    private void OnEnable()
    {
        JumpAction.action.performed += JUMP;
        JumpAction.action.canceled += JUMP;
    }
    private void OnDisable()
    {
        JumpAction.action.performed -= JUMP;
        JumpAction.action.canceled -= JUMP;
    }

    void JUMP(InputAction.CallbackContext callbackContext)
    {
        if (JumpAction.action.IsPressed())
        {
            Isjumping = true;
        }
        else { Isjumping = false; }
    }

    private void Update()
    {
        if (Isjumping) {
            Debug.Log("deus");
        }
    }

}
