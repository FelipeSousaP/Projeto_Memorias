using UnityEngine;

public class CollectAction : MonoBehaviour
{
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
            }
            else
            {
                other.gameObject.SetActive(false);
            }

        }
    }
}