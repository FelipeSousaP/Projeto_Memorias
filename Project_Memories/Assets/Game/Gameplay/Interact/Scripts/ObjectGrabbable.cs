using UnityEngine;
namespace Memorias.Gameplay.Interact
{
    public class ObjectGrabbable : MonoBehaviour, IInteractable
    {
        [Header("FeedBack Settings")]
        [SerializeField] private Color _interactColor;
        [SerializeField] private Color _SelectedColor;
        [SerializeField] private Renderer _renderer;

        //public PlayerInteract _interact;
        
        private Color _oldColor;
        private void Start()
        {
            _oldColor = _renderer.material.color;
        }
        public void Deselected()
        {
            _renderer.material.color = _oldColor;
        }
        public void OnInteract()
        {
            _renderer.material.color = _interactColor;
            /*
             * 1. Atribuir
             */
        }
        public void Selected()
        {
            _renderer.material.color = _SelectedColor;
        }
    }
}
