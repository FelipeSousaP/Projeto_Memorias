using UnityEngine;

public class CollectAction : MonoBehaviour
{
    //TEMP
    public int contador = 0;
    public Exemple_SceneControler sceneControler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Photos>(out Photos Foto))
        {
            // 1. Ativa a UI
            if (Foto.foto != null)
            {
                UIManeger.Instance.Show(Foto.foto);
            }

            if (Foto.chefe != null)
            {
                Foto.chefe.RecolherFoto(other.gameObject);
                //TEMP
                contador++;
            }
            else
            {
                other.gameObject.SetActive(false);
            }

        }

        if (contador == 2) {
            sceneControler.LoadScene("Controls");
        }
    }
}