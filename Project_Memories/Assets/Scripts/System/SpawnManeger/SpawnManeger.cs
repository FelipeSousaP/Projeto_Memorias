using UnityEngine;

namespace Memorias.System.SpawnManeger
{
    public class Spawnmaneger : MonoBehaviour
    {
        public static Spawnmaneger Instance;
        private Vector3 LastPoint;
        void Awake()
        {
            if (Instance == null) { Instance = this; }
            else { Destroy(this.gameObject); }
        }

        public void UpdateCheckPoint(Vector3 point)
        {
            Debug.Log(gameObject.name);
            LastPoint = point;
        }

        public Vector3 ReturnCheckPoint() => LastPoint;

    }
}

