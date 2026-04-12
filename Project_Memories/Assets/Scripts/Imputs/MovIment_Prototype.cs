using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Input References")]
        [SerializeField] private InputActionReference moveAction;

        [Header("Movement Settings")]
        [SerializeField] private float speed = 8f;
        [SerializeField] private Transform cameraTransform;

        [Header("Physics Settings")]
        [SerializeField] private float gravity = -30f;

        private CharacterController controller;
        private Vector2 inputDirection;
        private float verticalVelocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();

            
            if (cameraTransform == null && Camera.main != null)
                cameraTransform = Camera.main.transform;
        }

        private void OnEnable()
        {
            if (moveAction != null)
            {
                moveAction.action.performed += OnMovePerformed;
                moveAction.action.canceled += OnMoveCanceled;
            }
        }

        private void OnDisable()
        {
            if (moveAction != null)
            {
                moveAction.action.performed -= OnMovePerformed;
                moveAction.action.canceled -= OnMoveCanceled;
            }
        }

        private void OnMovePerformed(InputAction.CallbackContext context) => inputDirection = context.ReadValue<Vector2>();
        private void OnMoveCanceled(InputAction.CallbackContext context) => inputDirection = Vector2.zero;

        private void Update()
        {
            ApplyGravity();
            MovePlayer();
        }

        private void ApplyGravity()
        {
            
            if (controller.isGrounded && verticalVelocity < 0)
            {
                verticalVelocity = -2f;
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime;
            }
        }

        private void MovePlayer()
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();
            Vector3 movement = (forward * inputDirection.y) + (right * inputDirection.x);
            Vector3 finalMotion = movement * speed;
            finalMotion.y = verticalVelocity;
            controller.Move(finalMotion * Time.deltaTime);
        }
    }
}