using UnityEngine;
using UnityEngine.Events;

public class Exemple_Button : MonoBehaviour
{
    [SerializeField] private UnityEvent _onclick;

    public void EnableTower()
    {
        _onclick.Invoke();
    }
}
