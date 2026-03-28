using UnityEngine;

public class Exemple_MovingPlus : MonoBehaviour{

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }

    /*[SerializeField] private float maxDistance = 300f;
    [SerializeField] private Vector3 boxSizeMultiplier = Vector3.one * 0.5f;

    private Collider col;
    private RaycastHit hit;
    private bool hitDetected;

    void Awake() {
        col = GetComponent<Collider>();
    }

    void FixedUpdate() {
        Vector3 halfExtents = Vector3.Scale(transform.localScale, boxSizeMultiplier);
        Vector3 origin = col.bounds.center;
        Vector3 direction = transform.up;

        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        hitDetected = Physics.BoxCast(
            origin,
            halfExtents,
            direction,
            out hit,
            transform.rotation,
            maxDistance);

        if (hitDetected) {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + hit.collider.name);
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos() {
        Gizmos.color = Color.red;

        if (hitDetected) {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.up * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.up * hit.distance, transform.localScale);
        } else {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.up * maxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.up * maxDistance, transform.localScale);
        }
    }*/
}
