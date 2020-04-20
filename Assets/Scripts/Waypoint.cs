using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum Type
    {
        START,
        CONNECTION,
        END
    }

    //linkage

    public Waypoint prevWaypoint;
    public Waypoint nextWaypoint;
    //private
    [SerializeField]
    private Type _type;
    public Type type { get { return _type; } }

    public void SetType(Type t)
    {
        t = _type;
    }
}
