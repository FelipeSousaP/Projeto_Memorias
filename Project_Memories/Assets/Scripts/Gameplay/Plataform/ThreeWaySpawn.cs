using UnityEngine;
using UnityEngine.Events;

public class ThreeWaySpawn : MonoBehaviour{
    public int _Count = 0;
    public GameObject gO;

    public void CountUp() {
        _Count++;
    }

    public void Update() {
        if (_Count == 3) {
            gO.SetActive(true);
        }
    }
}
