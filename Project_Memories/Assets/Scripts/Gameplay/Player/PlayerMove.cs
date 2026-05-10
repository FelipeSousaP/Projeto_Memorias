using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("Move Settings")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform _player;
        public float Speed;
        public float RotationSpeed = 10f;

        [Header("Input Settings")]
        [SerializeField] InputActionReference MoveAction;

        [Header("Animation Settings")]
        [Tooltip("Coloque o nome do parametro que está sendo usado para ativar essa animação")]
        [SerializeField] private string _walkCondition;
        [SerializeField] private Animator _animator;

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
            if (Direção.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(Direção);
                _player.rotation = Quaternion.Slerp(_player.rotation, targetRotation, RotationSpeed * Time.deltaTime);
                rb.linearVelocity = new Vector3(Direção.x * Speed, rb.linearVelocity.y, Direção.z * Speed);
                _animator.SetBool(_walkCondition, true);
            }
            else
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                _animator.SetBool(_walkCondition, false);
            }
        }
    }

}