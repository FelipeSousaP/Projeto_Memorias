using UnityEngine;
namespace Memorias.Gameplay.Interact
{
    public class ObjectGrabbable : MonoBehaviour, IInteractable
    {
        [Header("FeedBack Settings")]
        [SerializeField] private Color _interactColor;
        [SerializeField] private Color _SelectedColor;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float _lerpSpeed;

        public PlayerInteract _interact;
        
        private Color _oldColor;
        private Rigidbody _rb;
        private void Start()
        {
            _oldColor = _renderer.material.color;
            _rb = GetComponent<Rigidbody>();
        }
        public void Deselected()
        {
            _renderer.material.color = _oldColor;
        }
        public void OnInteract()
        {
            _renderer.material.color = _interactColor;
            Vector3 target = _interact._grabPosition.position;
            _rb.MovePosition(Vector3.Lerp(transform.position,target,Time.deltaTime * _lerpSpeed));
        }
        public void Selected()
        {
            Debug.Log("Foi selecionado");
            _renderer.material.color = _SelectedColor;
        }
    }
}
