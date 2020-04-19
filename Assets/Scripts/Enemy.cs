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
        if (!_isAttacking && _currentPoint)
        {
            _rigidbody.velocity = (_currentPoint.transform.position - gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
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

    public void SetWaypoint(Waypoint point)
    {
        _currentPoint = point;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
