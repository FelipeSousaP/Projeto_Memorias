using UnityEngine;
using Memorias.Framework.ObjectPool;
using System.Collections;
using System;
namespace Memorias.System.PhotoManeger
{
    public enum CurrentPhase
    {
        Phase1,
        Phase2, 
        Phase3
    }
    public class PhotoSpawner : MonoBehaviour
    {
        #region Etapa 1: Requisitos
        [Header("Phase Settings")]
        [Tooltip("Cada array representa os pontos de Spawn de cada area do jogo")]
        [SerializeField] private PhotoAwaker _photoAwaker;
        [SerializeField] private Transform[] _phaseStart;
        [SerializeField] private Transform[] _phase2;
        [SerializeField] private Transform[] _phase3;
        
        private CurrentPhase _currentPhase;
        private int _currentPhotoIndex;
        #endregion
        
        private IEnumerator Start()
        {
            _currentPhase = CurrentPhase.Phase1;
            _currentPhotoIndex = 0;
            yield return null;
            NextSpawn();
        }

        public void PlayerIsTouched()
        {
            _currentPhotoIndex++;
            NextSpawn();
        }
        private void NextSpawn()
        {
            Transform[] CurrentArray = GetArray();

            if (_currentPhotoIndex >= CurrentArray.Length)
            {
                bool _nextPhase = NextPhase();
                if (_nextPhase) 
                {
                    _currentPhotoIndex = 0;
                    NextSpawn();
                }
                return;// para evitar que a recursividade, pegue +1 foto do ObjectPool
            }

            GameObject Photo = ObjectPoolController.Instance.objectPool.GetPool();
            Photo.transform.position = CurrentArray[_currentPhotoIndex].transform.position;
            Photo.SetActive(true);
        }
        private Transform[] GetArray()
        {
            switch (_currentPhase)
            {
                case CurrentPhase.Phase1:
                    return _phaseStart;
                case CurrentPhase.Phase2:
                    return _phase2;
                case CurrentPhase.Phase3:
                    return _phase3;
                default:
                    return null;
            }
        }
        private bool NextPhase()
        {
            int index = (int)_currentPhase + 1;
            if(index < Enum.GetNames(typeof(CurrentPhase)).Length)
            {
                _currentPhase = (CurrentPhase)index;
                return true;
            }
            return false;
        }
    }
}
