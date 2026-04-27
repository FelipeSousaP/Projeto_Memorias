using UnityEngine;
using Memorias.Framework.ObjectPool;
using System.Collections;
namespace Memorias.System.PhotoManeger
{
    public class PhotoAwaker : MonoBehaviour
    {
        [Header("Photo Settings")]
        [SerializeField] private GameObject PhotoPrefab;
        [SerializeField] private GameObject PhotoConteiner;
        public int quantidadeDEFotos;
        
        private void Start()
        {
            for (int i = 0; i < quantidadeDEFotos; i++) 
            {
                GameObject obj = Instantiate(PhotoPrefab,PhotoConteiner.transform);
                obj.SetActive(false);
                ObjectPoolController.Instance.objectPool.SetPool(obj);
                Debug.Log(obj.name + "Criado");
            }
        }
    }

}
