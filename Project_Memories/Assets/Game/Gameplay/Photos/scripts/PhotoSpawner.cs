using UnityEngine;
namespace Memorias.Gameplay.Photo
{
    public class PhotoSpawner : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] GameObject PhotoPrefab;
        [SerializeField] GameObject PhotoConteiner;
        [SerializeField] Transform[] PhotoPosition;
        [SerializeField] int QuantidadeDEFotos;

        private void Start()
        {
            for (int i = 0; i < QuantidadeDEFotos; i++) 
            {
                GameObject obj = Instantiate(PhotoPrefab,PhotoPosition[i].position,Quaternion.identity,PhotoConteiner.transform);
                Debug.Log("Criado");
            }
        }
    }
}
