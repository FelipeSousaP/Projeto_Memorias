using System;
using UnityEngine;

public class Plataform_Plataform_Move : MonoBehaviour{
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(transform, true);
            Debug.Log("Pai atual: " + other.transform.parent.name);
        }
        if (other.transform.CompareTag("Caixa")) {
            other.transform.SetParent(transform, true);
            Debug.Log("Pai atual: " + other.transform.parent.name);
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (!GetComponent<Collider>().bounds.Contains(other.transform.position)) {
                other.transform.SetParent(null);
            }
        }
        if (other.CompareTag("Caixa")) {
            other.transform.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
            other.transform.SetParent(null);
        }
    }
}
