using UnityEngine;
using System.Collections.Generic;

public class Exemple_Moving : MonoBehaviour {
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private Transform _mainPlat;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _pointRoot;

    private Transform _targetPoint;
    private int _currentPoint = 0;
    private int _dir = 1;

    private void Awake() {
        SetPoints();
    }

    private void FixedUpdate() {
        MoveThroughPoint();
    }

    private void MoveThroughPoint() {
        if (_points.Count == 0 || _mainPlat == null)
            return;

        _targetPoint = _points[_currentPoint];

        _mainPlat.position = Vector3.MoveTowards(
            _mainPlat.position,
            _targetPoint.position,
            _speed * Time.deltaTime
        );

        if (Vector3.Distance(_mainPlat.position, _targetPoint.position) < 0.05f) {
            _currentPoint += _dir;

            if (_currentPoint >= _points.Count) {
                _currentPoint = _points.Count - 2;
                _dir = -1;
            } else if (_currentPoint < 0) {
                _currentPoint = 1;
                _dir = 1;
            }
        }
    }

    private void SetPoints() {
        _points.Clear();

        if (_pointRoot == null)
            return;

        foreach (Transform t in _pointRoot) {
            _points.Add(t);
        }
    }
}