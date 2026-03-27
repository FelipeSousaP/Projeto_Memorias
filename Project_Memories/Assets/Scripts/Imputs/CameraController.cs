using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] InputActionReference MouseAction;
    [SerializeField] bool IsRotating;
    //[SerializeField] GameObject ThirdPersonCamera;
   
    private void OnEnable()
    {
        if(MouseAction != null)
        {
            MouseAction.action.performed += RotateCamera;
            MouseAction.action.canceled += RotateCamera;
        }
    }
    public void RotateCamera(InputAction.CallbackContext callbackContext)
    {
        IsRotating = callbackContext.ReadValueAsButton();
    }
    void Update()
    {
        if (IsRotating)
        {
            Cursor.lockState = CursorLockMode.Locked;// Congelar o cursor no ponto em especifico
            // Deixar o cursor visivel
            // ativar cinemachine
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnDisable()
    {
         MouseAction.action.performed -= RotateCamera;    
         MouseAction.action.canceled -= RotateCamera;    
    }
}
