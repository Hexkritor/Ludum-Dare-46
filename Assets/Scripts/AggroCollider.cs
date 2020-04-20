using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroCollider : MonoBehaviour
{
    [SerializeField]
    private Unit _unit;
    [SerializeField]
    private LayerMask _mask;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _mask.value)
        {
            _unit.SetAggro(true);
            _unit.SetAttackingUnit(col.gameObject.GetComponent<Unit>());
        }
    }
}
