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

        [Header("Player Settings")]
        [Tooltip("Para termos acesso a posição do grab")]
        public PlayerInteract _interact;
        [Tooltip("Para termos acesso ao Speed do jogador")]
        public MovIment_Prototype _playermove;
        [SerializeField] private float _reudecedSpeed;

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
            _playermove.Speed = _reudecedSpeed;
            Vector3 target = _interact._grabPosition.position;
            _rb.MovePosition(Vector3.Lerp(transform.position,target,Time.deltaTime * _lerpSpeed));
        }
        public void Selected()
        {
            _renderer.material.color = _SelectedColor;
        }
    }
}
