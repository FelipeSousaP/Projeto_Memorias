using UnityEngine;

public class keyRotation : MonoBehaviour{
    private float _speed;
    void Start() {
        _speed = 100f;
    }

    void Update() {
        transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }
}
