using UnityEngine;
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
      
        [Header("Floor Detector Setiings")]
        [SerializeField] private float _distanceRayCast;
        [SerializeField] private LayerMask _layerMask;

        private Color _oldColor;
        private Rigidbody _rb;
        private void Start()
        {
            _oldColor = _renderer.material.color;
            _rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,Vector3.down,out hit, _distanceRayCast,_layerMask))
            {
                Debug.Log("Achou!!!!");
            }
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
    }
}
