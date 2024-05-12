using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector3 _targetPos;
    private float _speed;
    private float _minDistance;

    private bool _followTarget;
    private float t; //Used for Lerp in Update

    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!_followTarget)
            return;

        t += Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(transform.position, _targetPos, t);
        if (Vector3.Distance(transform.position, _targetPos) <= _minDistance)
        {
            t = 0;
            _followTarget = false;
            gameObject.SetActive(false);
        }
    }
    public void MoveTowardsTarget(Vector3 targetPos, float speed ,float minDistance)
    {
        _targetPos = targetPos;
        _speed = speed;
        _minDistance = minDistance;
        _followTarget = true;
    }
}
