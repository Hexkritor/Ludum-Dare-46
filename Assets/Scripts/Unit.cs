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
    protected int _damage;
    [SerializeField]
    protected float _attackSpeed;
    [SerializeField]
    protected float _rangeToAttack;
    protected float _attackCooldown;
    protected bool _isAttacking;

    public Type type { get { return _type; } }
    public int maxHp { get { return _maxHp; } }
    public int damage { get { return _damage; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _hp = _maxHp;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    protected virtual void Move()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
