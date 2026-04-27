using Memorias.Gameplay.Player;
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
        [SerializeField] private float _reudecedSpeed;

        [Header("Player Settings")]
        [Tooltip("Para termos acesso a posição do grab")]
        public PlayerInteract _interact;
        [Tooltip("Para termos acesso ao Speed do jogador")]
        public MovIment_Prototype _move;
        
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
            _move.Speed = _reudecedSpeed;
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
