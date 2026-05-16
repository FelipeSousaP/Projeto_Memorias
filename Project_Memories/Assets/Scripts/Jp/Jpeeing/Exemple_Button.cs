using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Exemple_Button : MonoBehaviour
{
    [SerializeField] private UnityEvent _onclick;
    [SerializeField] private LayerMask _player;
    [SerializeField] private float Distance;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject[] points;
    [SerializeField] private Rigidbody rb;
    public Vector3 firstSpawn;
    public Vector3 secondSpawn;
    RaycastHit hit;

    private void Start() {
        firstSpawn = points[0].transform.position;
        secondSpawn = points[1].transform.position;
        box.transform.position = points[0].transform.position;
        rb = box.GetComponent<Rigidbody>();
    }
    public void EnableTower()
    {
        _onclick.Invoke();
    }

    private void Update() {
        if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit hit, Distance, _player)) {
            if (box.transform.position.y < this.transform.position.y) {
                rb.isKinematic = true;
                box.transform.position = points[0].transform.position;
                rb.isKinematic = false;
            }
        }
    }
}
