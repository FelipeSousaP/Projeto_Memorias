using UnityEngine;

public class UnityNãoAceitaGenetico : MonoBehaviour
{
    private objectPool<GameObject> pool;
    private void Awake()
    {
        //a Unity não aceita generico, por tem <T> no nome do arquivo
        pool = new objectPool<GameObject>();
    }
}
