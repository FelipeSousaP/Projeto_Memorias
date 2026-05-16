using UnityEngine;
using UnityEngine.Events;

namespace Memorias.Gameplay.Interact
{
    public class ObjectGrabbable : MonoBehaviour, IInteractable
    {
        [Header("FeedBack Settings")]
        [SerializeField] private Color _interactColor;
        [SerializeField] private Color _SelectedColor;
        [SerializeField] private Renderer _renderer;
        public UnityEvent onSelect;
        public UnityEvent onDeselect;
        public LayerMask areaLayer;
        RaycastHit hit;

        [Header("Player Settings")]
        public PlayerInteract _interact;

        /*[Header("Floor Detector Setiings")]
        [SerializeField] private LayerMask _paredes;
        [SerializeField] private Vector3 _HalfBox;*/

        private Color _oldColor;
        private Rigidbody _rb;

        private void Start()
        {
            _oldColor = _renderer.material.color;
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
        }

        public void Deselected()
        {
            _renderer.material.color = _oldColor;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, areaLayer)) {
                onDeselect.Invoke();
            }
            //_rb.isKinematic = true;
        }

        public void OnInteract()
        {
            _renderer.material.color = _interactColor;
            //_rb.isKinematic = false;
            transform.SetParent(null);
            transform.position = _interact._grabPosition.position;
            transform.rotation = _interact._grabPosition.rotation;
        }
        public void Selected()
        {
            _renderer.material.color = _SelectedColor;
            onSelect.Invoke();
            //_rb.isKinematic = true;
        }
    }
}