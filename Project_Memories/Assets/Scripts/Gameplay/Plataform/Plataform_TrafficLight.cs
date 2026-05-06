using System.Collections.Generic;
using UnityEngine;

public class Plataform_TrafficLight : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private Transform _mainPlat;
    [SerializeField] private Transform _pointRoot;

    [Header("Move")]
    [SerializeField] private float _speed = 2f;

    private int _currentPoint = 0;
    private bool _isMoving = false;
    private Transform _targetPoint;
    private int _stepsRemaining = 0;
    private Rigidbody _rbPlat;

    private void Awake()
    {
        _rbPlat = _mainPlat.GetComponent<Rigidbody>();
        SetPoints();
        _mainPlat.position = _points[0].position;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (_targetPoint == null) return;

        Vector3 nextPos = Vector3.MoveTowards(
            _rbPlat.position,
            _targetPoint.position,
            _speed * Time.fixedDeltaTime
        );

        _rbPlat.MovePosition(nextPos);
        if (Vector3.Distance(_rbPlat.position, _targetPoint.position) < 0.05f)
        {
            _rbPlat.position = _targetPoint.position;
            _stepsRemaining--;

            if (_stepsRemaining > 0)
            {
                GoNextSinglePoint();
            }
            else
            {
                _isMoving = false;
            }
        }
    }

    public void NextPoint()
    {
        if (_points.Count == 0 || _isMoving) return;

        _stepsRemaining = 2;
        GoNextSinglePoint();
        _isMoving = true;
    }

    private void GoNextSinglePoint()
    {
        _currentPoint++;
        if (_currentPoint >= _points.Count)
            _currentPoint = 0;
        _targetPoint = _points[_currentPoint];
    }
    private void SetPoints()
    {
        _points.Clear();
        if (_pointRoot == null) return;
        foreach (Transform t in _pointRoot)
        {
            _points.Add(t);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Caixa"))
        {
            Debug.Log("player");
            other.transform.SetParent(_mainPlat);
            if (!_isMoving)
            {
                NextPoint();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Caixa"))
        {
            other.transform.SetParent(null);
        }
    }
}