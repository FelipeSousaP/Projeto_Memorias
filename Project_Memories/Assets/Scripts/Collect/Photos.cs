using UnityEngine;

public class Photos : MonoBehaviour
{
    public string name = "Teste";
    [SerializeField] CanvasGroup foto;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<MovIment_Prototype>(out MovIment_Prototype component))
        {
            UIManeger.Instance.Show(foto);
        }
    }
}
