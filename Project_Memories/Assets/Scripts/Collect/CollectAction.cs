using UnityEngine;

public class CollectAction : MonoBehaviour
{
    //Codigo destinado para a area de coleta de fotos
    objectPool<GameObject> pool;

    [Header("Fotos")]
    [SerializeField] CanvasGroup Foto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Photos>(out Photos component))  
        {
            Debug.Log($"Coletado: {component.name}");
            pool.SetPool(other.gameObject);        
            other.gameObject.SetActive(false);
        }
    }
}
