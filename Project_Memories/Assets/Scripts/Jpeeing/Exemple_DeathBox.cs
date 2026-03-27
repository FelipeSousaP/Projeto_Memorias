using UnityEngine;

public class Exemple_DeathBox : MonoBehaviour{
    [SerializeField] private Vector3 _inicialPos;
    [SerializeField] private GameObject player;

    private void Start() {
        _inicialPos = player.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            player.transform.position = _inicialPos;
        }
    }
}
