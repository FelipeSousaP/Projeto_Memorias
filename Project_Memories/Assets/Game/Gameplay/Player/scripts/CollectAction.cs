using UnityEngine;
using Memorias.Framework.ObjectPool;
using Memorias.System.PhotoManeger;
namespace Memorias.Gameplay.Player
{
    public class CollectAction : MonoBehaviour
    {
        [SerializeField] private PhotoSpawner _photoSpawner;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Photos>(out Photos component)) //Substituir por GetComponent<Photo>() 
            {
                Debug.Log($"Coletado: {component._name}");
                ObjectPoolController.Instance.objectPool.SetPool(other.gameObject);
                other.gameObject.SetActive(false);
                _photoSpawner.PlayerIsTouched();
            }
        }
    }
}
