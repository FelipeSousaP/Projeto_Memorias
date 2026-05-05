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

        [Header("Player Settings")]
        [Tooltip("Para termos acesso a posição do grab")]
        public PlayerInteract _interact;
        [SerializeField] private UnityEvent onArea;

        [Header("Floor Detector Setiings")]
        [SerializeField] private float _distanceRayCast;
        [SerializeField] private LayerMask _Plataformas;
        [SerializeField] private LayerMask _paredes;
        [SerializeField] private Vector3 _HalfBox;

        private Color _oldColor;
        private Rigidbody _rb;
        public bool _isOn;
        private void Start()
        {
            _oldColor = _renderer.material.color;
            _rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            Vector3 direction = -transform.right;
            if (Physics.BoxCast(transform.position, _HalfBox, direction, transform.rotation, _distanceRayCast, _paredes))
            {
                Debug.Log("YESS");
            }
            RaycastHit hit;
            bool col = Physics.Raycast(transform.position, Vector3.down, out hit, _distanceRayCast, _Plataformas);
            Debug.DrawRay(transform.position, Vector3.down * _distanceRayCast, col ? Color.green : Color.red);
            if (col)
            {
                Debug.Log("tocou no chão");
                if (!_isOn)
                {
                    OnPlace(hit.transform);
                }
            }
            else
            {
                if (_isOn)
                {
                    _isOn = false;
                    transform.SetParent(null);
                }
            }
        }

        void OnPlace(Transform plataform)
        {
            _isOn = true;
            transform.SetParent(plataform);
            onArea.Invoke();
        }

        public void Deselected() 
        {
            _renderer.material.color = _oldColor;
        }
        public void OnInteract()
        {
            _renderer.material.color = _interactColor;
            _rb.isKinematic = false;
            transform.position = _interact._grabPosition.position;
            transform.rotation = _interact._grabPosition.rotation;
        }
        public void Selected()
        {
            _renderer.material.color = _SelectedColor;
            _rb.isKinematic = true;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _HalfBox * 2);
        }
    }
}
