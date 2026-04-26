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

        private bool _interacting;
        private IInteractable _currentInterface;
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
        }
        #endregion

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(_playerPosition.position, _playerPosition.forward, out hit, _distanceRaycast) && hit.collider.TryGetComponent(out IInteractable I))
            {
                Debug.Log("Collidiu com o " + hit.collider.name);
                if(_currentInterface != I)
                {
                    _currentInterface = I;
                    _currentInterface.Selected();
                }
                if (_interacting){I.OnInteract();}
                else { I.Deselected(); }
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
