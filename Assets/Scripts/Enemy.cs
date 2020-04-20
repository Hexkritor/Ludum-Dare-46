﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField]
    private float distanceToWaypoint;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        if (_isAttacking)
        {
            _animator.SetBool("isAttacking", true);
            if (_attackingUnit)
            {
                if (Vector2.Distance(gameObject.transform.position, _attackingUnit.gameObject.transform.position) > _rangeToAttack)
                {
                    _isAttacking = false;
                    _animator.SetBool("isAttacking", false);
                }
            }
            else
            {
                _isAttacking = false;
            }
        }
        else if (_isAggro && !_isAttacking)
        {
            if (_attackingUnit)
            {
                if (Vector2.Distance(gameObject.transform.position, _attackingUnit.gameObject.transform.position) <= _rangeToAttack)
                {
                    _isAttacking = true;
                }
                else
                {
                    _rigidbody.velocity = ((Vector2)_currentPoint.transform.position - (Vector2)gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
                }
            }
            else
            {
                _isAggro = false;
            }
        }
        else if (!_isAttacking && !_isAggro && _currentPoint)
        {
            if (_rigidbody.velocity.magnitude <= _minSpeed)
                _lowMinSpeedTime += Time.fixedDeltaTime;
            else
                _lowMinSpeedTime = 0;
            if (_lowMinSpeedTime >= 1)
            {
                if (_currentPoint.nextWaypoint && _currentPoint.prevWaypoint)
                {
                    _currentPoint =
                        (Vector2.Distance(gameObject.transform.position, _currentPoint.nextWaypoint.transform.position) >
                        Vector2.Distance(gameObject.transform.position, _currentPoint.prevWaypoint.transform.position)) ? _currentPoint.prevWaypoint : _currentPoint.nextWaypoint;
                    _lowMinSpeedTime = 0;
                }
                else if (_currentPoint.nextWaypoint)
                {
                    _currentPoint =
                        (Vector2.Distance(gameObject.transform.position, _currentPoint.nextWaypoint.transform.position) >
                        Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position)) ? _currentPoint : _currentPoint.nextWaypoint;
                    _lowMinSpeedTime = 0;
                }
                else if (_currentPoint.prevWaypoint)
                {
                    _currentPoint =
                        (Vector2.Distance(gameObject.transform.position, _currentPoint.prevWaypoint.transform.position) >
                        Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position)) ? _currentPoint : _currentPoint.prevWaypoint;
                    _lowMinSpeedTime = 0;
                }
            }
            _rigidbody.velocity = ((Vector2)_currentPoint.transform.position - (Vector2)gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
        }
        else 
        {
            _rigidbody.velocity = Vector2.zero;
        }
        if (_currentPoint)
        {
            distanceToWaypoint = Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position);
            if (Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position) <= waypointRadius)
            {
                if (_currentPoint.type == Waypoint.Type.END)
                {
                    Destroy(gameObject);
                }
                else if (_currentPoint.nextWaypoint)
                {
                    _currentPoint = _currentPoint.nextWaypoint;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        UpdateLayerPosition();
    }
}
