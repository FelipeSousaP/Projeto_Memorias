using UnityEngine;
using Memorias.Framework.ObjectPool;
using Memorias.System.PhotoManeger;
using Memorias.System.AudioSystem;
namespace Memorias.Gameplay.Player
{
    public class CollectAction : MonoBehaviour
    {
        [SerializeField] private PhotoSpawner _photoSpawner;
        //Codigo destinado para a area de coleta de fotos
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<keyRotation>(out keyRotation component)) //Substituir por GetComponent<Photo>() 
            {
                AudioManeger.Instance.PlaySFXSound(SFXType.CollectKey);
                Debug.Log($"Coletado: {component.name}");
                //adicionar em uma lista
                ObjectPoolController.Instance.objectPool.SetPool(other.gameObject);
                other.gameObject.SetActive(false);
                _photoSpawner.PlayerIsTouched();
            }
        }
    }

}
