using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 _movingDirection;
    private float _speed;

    public void Initialize()
    {
        _speed = Random.Range(0.05f, 0.1f);
        while (_movingDirection == Vector3.zero)
            _movingDirection = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)) * _speed;
    }

    void Update()
    {
        transform.Translate(_movingDirection);
    }
}
