using UnityEngine;

public class Photo_Prototype : MonoBehaviour
{
    public void InteragirComFoto()
    {
        Collider c = GetComponent<Collider>(); // Não pegar foto mais de duas vezes
        if (c != null ) { c.enabled = false; }  // desativar colisor
        Destroy(gameObject);
    }
}
