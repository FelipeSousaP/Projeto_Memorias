using UnityEngine;

public class Exemple_MovingPlus : MonoBehaviour{

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }
}
