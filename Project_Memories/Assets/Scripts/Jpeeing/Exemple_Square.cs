using UnityEngine;

public class Exemple_Square : MonoBehaviour{
    [SerializeField] private Vector3 _inicialPos;

    private void Start() {
        _inicialPos = transform.position;
    }

    public void ReturnToOriginalPos() {
        transform.position = _inicialPos;
    }
}
