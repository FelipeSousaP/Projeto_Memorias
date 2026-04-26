using UnityEngine;
using UnityEngine.InputSystem;

namespace Memorias.Gameplay.Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Interact Settings")]
        [SerializeField] private InputActionReference _interactAction;
        [SerializeField] private Transform _playerPosition;
        [SerializeField] private float _distanceRaycast;
        public Transform _grabPosition;

        private bool _interacting;
        private IInteractable _interactable;
        private IInteractable _HeldObject;
        #endregion

        #region Etapa 2: Input do evento
        private void OnEnable()
        {
            if(_interactAction != null)
            {
                _interactAction.action.performed += OnInteractPerformed;
                _interactAction.action.canceled += OnInteractPerformed;
            }
        }
        private void OnDisable()
        {
            _interactAction.action.performed -= OnInteractPerformed;    
            _interactAction.action.canceled -= OnInteractPerformed;    
        }
        private void OnInteractPerformed(InputAction.CallbackContext callback)
        {
            _interacting = !_interacting;
            
            if (!_interacting)
            {
                _interactable.Deselected();
                _HeldObject = null;
            }
        }
        #endregion

        private void Update()
        {
            if(_interacting && _HeldObject != null)
            {
                _interactable.OnInteract();
            }
            RaycastHit hit;
            if (Physics.Raycast(_playerPosition.position, _playerPosition.forward, out hit, _distanceRaycast))
            {
                IInteractable I = hit.collider.GetComponent<IInteractable>();
                if (I != null)
                {
                    //Nao tem nada no _Interactable
                    if(_interactable != I)
                    {
                        _interactable = I;
                        _interactable.Selected();
                    }
                    if (_interacting)
                    {
                        _HeldObject = _interactable;
                    }
                }
                else
                {
                    CheckInterface();
                }
            }
            else
            {
                CheckInterface();
            }
        }
        private void CheckInterface()
        {
            if(_interactable != null)
            {
               _interactable.Deselected();
                _interactable = null;
            }
        }

        private void OnDrawGizmos()
        {
            Vector3 end = _playerPosition.position + (_distanceRaycast * _playerPosition.forward);
            Gizmos.DrawLine(_playerPosition.position, end);
            Gizmos.color = Color.blue;
        }
    }
}
