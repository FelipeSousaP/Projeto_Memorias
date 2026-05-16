using Memorias.System.SpawnManeger;
using UnityEngine;

public class Exemple_DeathBox : MonoBehaviour {
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            Debug.Log(player.transform.position);
            player.transform.position = Spawnmaneger.Instance.ReturnCheckPoint();
        }
    }
}

