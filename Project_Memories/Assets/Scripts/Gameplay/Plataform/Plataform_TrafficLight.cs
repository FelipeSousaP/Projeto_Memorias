using System.Collections.Generic;
using UnityEngine;

public class Plataform_TrafficLight : MonoBehaviour{
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

    private void Awake() {
        SetPoints();
        _mainPlat.position = _points[0].position;
    }

    private void Update() {
        if (_isMoving)
            MoveToPoint();
    }

    private void MoveToPoint() {
        if (_targetPoint == null) return;

        _mainPlat.position = Vector3.MoveTowards(
            _mainPlat.position,
            _targetPoint.position,
            _speed * Time.deltaTime
        );

        if (Vector3.Distance(_mainPlat.position, _targetPoint.position) < 0.05f) {
            _mainPlat.position = _targetPoint.position;

            _stepsRemaining--;

            if (_stepsRemaining > 0) {
                GoNextSinglePoint();
            } else {
                _isMoving = false;
            }
        }
    }

    public void NextPoint() {
        if (_points.Count == 0 || _isMoving) return;

        _stepsRemaining = 2;
        GoNextSinglePoint();
        _isMoving = true;
    }

    private void GoNextSinglePoint() {
        _currentPoint++;

        if (_currentPoint >= _points.Count)
            _currentPoint = 0;

        _targetPoint = _points[_currentPoint];
    }

    private void SetPoints() {
        _points.Clear();

        if (_pointRoot == null) return;

        foreach (Transform t in _pointRoot) {
            _points.Add(t);
        }
    }
}
