using System.Collections.Generic;
using UnityEngine;

public class PhotoListManeger : MonoBehaviour
{
    static PhotoListManeger instance;
    List<GameObject> Photos = new(); // Preciso inicializar a lista

    #region Singloton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            //escrever this ao inves de new PhotoListManeger();
        }
        else
        {
            Destroy(gameObject); //evitar duplicação
        }
    }

    public static PhotoListManeger Instance => instance;
    #endregion

    public void SetPhotos(GameObject gameObject)
    {
        Photos.Add(gameObject);
    }
    public int GetPhotoNumber()
    {
        // retornar valor de fotos
        return Photos.Count;
    }
}
