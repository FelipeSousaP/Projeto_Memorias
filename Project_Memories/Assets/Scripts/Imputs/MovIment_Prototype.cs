using UnityEngine;
using UnityEngine.InputSystem;

public class MovIment_Prototype : MonoBehaviour
{
    [SerializeField] InputActionReference MoveAction;
    [SerializeField] float Speed;
    Vector2 valor;
    Transform CAMtransform;
    private void Start()
    {
        CAMtransform = Camera.main.transform;
    }
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
        Vector3 FrenteEtras = CAMtransform.forward;
        Vector3 Lado = CAMtransform.right;
        #region Controle de dados
        FrenteEtras.y = 0f;
        Lado.y = 0f;
        Lado.Normalize();
        FrenteEtras.Normalize(); // não é possivel misturar void com float
        #endregion
        Vector3 Direção = (FrenteEtras * valor.y) + (Lado * valor.x);
        transform.Translate(Direção * Speed * Time.deltaTime,Space.World);//Em relação ao mundo
    }
}
