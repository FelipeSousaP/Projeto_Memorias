using UnityEngine;
using Memorias.Gameplay.Photo;
namespace Memorias.Gameplay.Player
{
    public class CollectAction : MonoBehaviour
    {
        //Codigo destinado para a area de coleta de fotos
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Photos>(out Photos component)) //Substituir por GetComponent<Photo>() 
            {
                Debug.Log($"Coletado: {component.name}");
                //adicionar em uma lista
                PhotoListManeger.Instance.SetPhotos(other.gameObject);
                other.gameObject.SetActive(false);
                Debug.Log($"Fotos: {PhotoListManeger.Instance.GetPhotoNumber()} ");
            }
        }
    }

}
