using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public GameObject selectCircle;

    [SerializeField]
    private float distanceToWaypoint;

    public bool isSelected { set { selectCircle.SetActive(value); } }

    override protected void Start()
    {
        base.Start();
        selectCircle.SetActive(false);
    }

    protected override void Move()
    {
        if (_isAttacking)
        {
            _animator.SetBool("isAttacking", true);
            if (_attackingUnit)
            {
                _rigidbody.velocity = Vector2.zero;
                if (Vector2.Distance(gameObject.transform.position, _attackingUnit.gameObject.transform.position) > _rangeToAttack)
                {
                    _isAttacking = false;
                    _animator.SetBool("isAttacking", false);
                }
            }
            else
            {
                _isAttacking = false;
                _animator.SetBool("isAttacking", false);
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
                else if (Vector2.Distance(gameObject.transform.position, _attackingUnit.gameObject.transform.position) <= _rangeAggro)
                {
                    _rigidbody.velocity = ((Vector2)_currentPoint.transform.position - (Vector2)gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
                }
                else
                {
                    _attackingUnit = null;
                    _isAggro = false;
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
                _currentPoint = null;
                _lowMinSpeedTime = 0;
            }
            if (_currentPoint)
                _rigidbody.velocity = ((Vector2)_currentPoint.transform.position - (Vector2)gameObject.transform.position).normalized * _speed * Time.fixedDeltaTime;
            _animator.SetBool("isMoving", true);
            foreach (SpriteRenderer _render in _renders)
                _render.flipX = _rigidbody.velocity.normalized.x < 0;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            _animator.SetBool("isMoving", false);
        }
        if (_currentPoint)
        {
            distanceToWaypoint = Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position);
            if (Vector2.Distance(gameObject.transform.position, _currentPoint.transform.position) <= waypointRadius)
            {
                if (_currentPoint.nextWaypoint)
                {
                    _currentPoint = _currentPoint.nextWaypoint;
                }
                else
                {
                    _currentPoint = null;
                }
            }
        }
    }

    public override void SetAttackingUnit(Unit unit)
    {
        if (!_attackingUnit)
            _attackingUnit = unit;
    }

    void FixedUpdate()
    {
        if (!_isDead)
            Move();
        UpdateLayerPosition();
    }
}
