using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] InputActionReference MouseAction;
    [SerializeField] bool IsRotating;

    [Header("Cursor & Camera")]
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject Cinemachine;
    Vector2 Mousepos;
    private void OnEnable()
    {
        if (MouseAction != null)
        {
            MouseAction.action.performed += RotateCamera;
            MouseAction.action.canceled += RotateCamera;
        }
    }
    public void RotateCamera(InputAction.CallbackContext callbackContext)
    {
        IsRotating = callbackContext.ReadValueAsButton();
        if (IsRotating) 
        {
            Mousepos = Mouse.current.position.ReadValue(); // ver posição atual do mouse
        }
    }
    void Update()
    {
        if (IsRotating)
        {
            Cursor.lockState = CursorLockMode.Locked;// Congelar o cursor no ponto em especifico
            cursor.transform.position = Mousepos; // ficar preso na posição antiga
            Cursor.visible = false;
            Cinemachine.SetActive(true); // ATIVAR CINEMACHINE
        }
        else
        {
            Cinemachine.SetActive(false); // DESLIGA a cinemachine
            Cursor.lockState = CursorLockMode.None; // deixar mouse livre
            Cursor.visible = true;

            Vector2 mousepos = Mouse.current.position.ReadValue(); // ver posição atual do mouse
            cursor.transform.position = mousepos; //posição do cursor igual a mouse
        }
    }
    private void OnDisable()
    {
        MouseAction.action.performed -= RotateCamera;
        MouseAction.action.canceled -= RotateCamera;
    }
}
