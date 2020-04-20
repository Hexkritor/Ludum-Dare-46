using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type
    {
        TANK,
        ATTACK,
        MAGE
    }

    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    [SerializeField]
    protected CircleCollider2D _aggroTrigger;
    [SerializeField]
    protected SpriteRenderer _render;


    [SerializeField]
    protected Unit _attackingUnit;

    [SerializeField]
    protected Waypoint _currentPoint;
    [SerializeField]
    protected float waypointRadius;
    [SerializeField]
    protected Type _type;
    [SerializeField]
    protected int _maxHp;
    protected int _hp;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected float _minSpeed;
    protected float _lowMinSpeedTime;
    [SerializeField]
    protected int _damage;
    [SerializeField]
    protected float _rangeToAttack;
    [SerializeField]
    protected float _rangeAggro;
    protected bool _isAttacking;
    protected bool _isAggro;
    protected bool _isDead;

    public Type type { get { return _type; } }
    public int maxHp { get { return _maxHp; } }
    public int damage { get { return _damage; } }
    public bool canBeAttacked { get { return !_isDead; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _hp = _maxHp;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        if (_aggroTrigger)
            _aggroTrigger.radius = _rangeAggro;
    }

    protected virtual void Move()
    {

    }

    public void SetWaypoint(Waypoint point)
    {
        _currentPoint = point;
    }

    public void UpdateLayerPosition()
    {
        _render.sortingOrder = -Mathf.FloorToInt(gameObject.transform.position.y * 20);
    }

    public void SetAggro(bool value)
    {
        _isAggro = value;
    }

    public void Attack()
    {
        if (_attackingUnit)
        {
            if (_attackingUnit.canBeAttacked)
                _attackingUnit.TakeDamage(_damage);
        }
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _isDead = true;
            _animator.SetBool("isDead", true);
        }
    }

    public void RemoveUnit()
    {
        Destroy(gameObject);
    }

    public virtual void SetAttackingUnit(Unit unit)
    {
        _attackingUnit = unit;
    }
}
