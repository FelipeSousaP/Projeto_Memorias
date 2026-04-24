using UnityEngine;
using Memorias.Framework.ObjectPool;
namespace Memorias.Gameplay.Player
{
    public class CollectAction : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Photos>(out Photos component)) //Substituir por GetComponent<Photo>() 
            {
                Debug.Log($"Coletado: {component._name}");
                ObjectPoolController.Instance.objectPool.SetPool(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
    }
}
