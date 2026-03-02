using UnityEngine;
using UnityEngine.InputSystem;

public class MovIment_Prototype : MonoBehaviour
{
    [SerializeField] InputActionReference MoveAction;
    [SerializeField] float Speed;
    Vector2 valor;

    private void OnEnable()
    {
        if (MoveAction != null) // para não chamar um evento que não existe
        {
            MoveAction.action.performed += Move;
            MoveAction.action.canceled += Move;
        }
    }
    private void OnDisable()
    {
        MoveAction.action.performed -= Move;
        //Sem o canceled é infinito
        MoveAction.action.canceled -= Move;
    }
    private void Move(InputAction.CallbackContext callbackContext)
    {
        valor = callbackContext.ReadValue<Vector2>();
    }
    void Update()
    {
        Vector3 dir = new Vector3(valor.x,0,valor.y);
        transform.Translate(dir * Speed * Time.deltaTime);
    }
}
