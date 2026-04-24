using UnityEngine;
using Memorias.Framework.ObjectPool;
using System.Collections;
namespace Memorias.System.PhotoManeger
{
    public class PhotoSpawner : MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Phase Settings")]
        [Tooltip("Cada array representa os pontos de Spawn de cada area do jogo")]
        [SerializeField] private PhotoAwaker _photoAwaker;
        [SerializeField] private Transform[] _phase1;
        #endregion
        
        //talvez usar Ienumerator
        private IEnumerator Start()
        {
            yield return null;
            for (int i = 0; i < _photoAwaker.quantidadeDEFotos; i++) 
            {
                //if (i >= _photoAwaker.quantidadeDEFotos) break;
                GameObject Photo = ObjectPoolController.Instance.objectPool.GetPool();
                Photo.transform.position = _phase1[i].transform.position;
                Photo.SetActive(true);
                Debug.Log("Gerando Objeto em: " + Photo.transform.position);
            }      
        }
    }
}
