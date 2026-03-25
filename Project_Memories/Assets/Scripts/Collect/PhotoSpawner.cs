using UnityEngine;

public class PhotoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject photoPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private CanvasGroup[] listaDeFotosNaUI;
    // Nome da Tua Classe <Tipo de Objeto> NomeDaVariavel = new NomeDaTuaClasse <Tipo de Objeto>();
    private objectPool<GameObject> Fotos = new objectPool<GameObject>();
    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject novaFoto = Instantiate(photoPrefab, spawnPoints[i].position, Quaternion.identity);

            if (novaFoto.TryGetComponent<Photos>(out Photos Foto))
            {
                Foto.foto = listaDeFotosNaUI[i];

                // A foto agora sabe quem é o Spawner dela!
                Foto.chefe = this;

                Fotos.SetPool(novaFoto);
            }
        }
    }
    public void RecolherFoto(GameObject fotoObjeto)
    {
        fotoObjeto.SetActive(false); 
        Fotos.SetPool(fotoObjeto);   
    }
}