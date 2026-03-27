using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] InputActionReference MouseAction;
    [SerializeField] bool IsRotating;

    [Header("Cursor & Camera")]
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject Cinemachine;
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
        #region Cursor seguindo o mouse
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        cursor.transform.position = mousePosition; //O cursor fake
        Vector2 PosiçãoAntiga = cursor.transform.position;
        Cursor.visible = false; // Cursor real
        #endregion
        //imagem seguindo o cursor
        if (IsRotating)
        {
            Cursor.lockState = CursorLockMode.Confined;// Congelar o cursor no ponto em especifico
            cursor.transform.position = PosiçãoAntiga;

            // imagem do cursor congela
            Cinemachine.SetActive(IsRotating);// ativar cinemachine
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }

    private void OnDisable()
    {
         MouseAction.action.performed -= RotateCamera;    
         MouseAction.action.canceled -= RotateCamera;    
    }
}
