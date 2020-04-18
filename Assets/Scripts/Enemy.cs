using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField]
    private Waypoint currentPoint;
    [SerializeField]
    private float waypointRadius;
    [SerializeField]
    private float distanceToWaypoint;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        if (!_isAttacking && currentPoint)
        {
            _rigidbody.velocity = (currentPoint.transform.position - gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
        }
        distanceToWaypoint = Vector2.Distance(gameObject.transform.position, currentPoint.transform.position);
        if (Vector2.Distance(gameObject.transform.position, currentPoint.transform.position) <= waypointRadius)
        {
            print("TRIGGERED");
            if (currentPoint.type == Waypoint.Type.END)
            {
                Destroy(gameObject);
            }
            else if (currentPoint.nextWaypoint)
            {
                currentPoint = currentPoint.nextWaypoint;
            }
        }
    }

    public void SetWaypoint(Waypoint point)
    {
        currentPoint = point;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
