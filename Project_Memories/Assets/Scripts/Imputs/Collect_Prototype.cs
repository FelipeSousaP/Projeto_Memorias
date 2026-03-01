using UnityEngine;
using System.Collections.Generic;

public class Collect_Prototype : MonoBehaviour
{
    [SerializeField] List<GameObject> Photos;
    private void OnCollisionEnter(Collision collision)
    {
        Photo_Prototype Foto = collision.gameObject.GetComponent<Photo_Prototype>();
        if (Foto != null) 
        {
            Photos.Add(collision.gameObject); //O Objeto interagido pelo jogador será armazenado
            Debug.Log(Photos.Count);
            Foto.InteragirComFoto(); // para fazer objeto sumir
        }
    }
}
