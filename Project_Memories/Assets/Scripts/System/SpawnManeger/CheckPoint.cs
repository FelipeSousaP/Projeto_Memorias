using Memorias.System.SpawnManeger;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckPoint : MonoBehaviour
{
    bool Active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!Active && other.GetComponent<PlayerInput>())
        {
            Active = true;
            Spawnmaneger.Instance.UpdateCheckPoint(transform.position);        }
    }
}
