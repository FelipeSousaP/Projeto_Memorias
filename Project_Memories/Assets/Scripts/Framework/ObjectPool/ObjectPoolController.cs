using UnityEngine;

namespace Memorias.Framework.ObjectPool
{
    public class ObjectPoolController : MonoBehaviour
    {
        public static ObjectPoolController Instance {  get; private set; }
        public ObjectPool<GameObject> objectPool { get; private set; }    
        // Atribuir o "Get; private set;" nenhum codigo externo pode alterar o Singloton apenas le-lo
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                objectPool = new ObjectPool<GameObject>();
            }
        }
    }
}
