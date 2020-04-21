using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy worker;
    public Enemy cleric;
    public Enemy fbi;
    public Waypoint startPoint;

    public Vector3 daySpawnLimit;

    [SerializeField]
    private float _workerSpawnDelay;
    private float _workerSpawnCooldown;
    [SerializeField]
    private float _clericSpawnDelay;
    private float _clericSpawnCooldown;
    [SerializeField]
    private float _fbiSpawnDelay;
    private float _fbiSpawnCooldown;

    void Start()
    {
        _workerSpawnCooldown = _workerSpawnDelay;
        _clericSpawnCooldown = _clericSpawnDelay;
        _fbiSpawnCooldown = _fbiSpawnDelay;
    }

    void Update()
    {
        if (_workerSpawnCooldown <= 0 && daySpawnLimit.x > 0)
        {
            Enemy e = Instantiate(worker, startPoint.transform.position, Quaternion.Euler(Vector3.zero));
            e.SetWaypoint(startPoint);
            _workerSpawnCooldown = _workerSpawnDelay;
            --daySpawnLimit.x;
        }
        _workerSpawnCooldown -= Time.deltaTime;
        if (_clericSpawnCooldown <= 0 && daySpawnLimit.y > 0)
        {
            Enemy e = Instantiate(cleric, startPoint.transform.position, Quaternion.Euler(Vector3.zero));
            e.SetWaypoint(startPoint);
            _clericSpawnCooldown = _clericSpawnDelay;
            --daySpawnLimit.y;
        }
        _clericSpawnCooldown -= Time.deltaTime;
        if (_fbiSpawnCooldown <= 0 && daySpawnLimit.z > 0)
        {
            Enemy e = Instantiate(fbi, startPoint.transform.position, Quaternion.Euler(Vector3.zero));
            e.SetWaypoint(startPoint);
            _fbiSpawnCooldown = _fbiSpawnDelay;
            --daySpawnLimit.z;
        }
        _fbiSpawnCooldown -= Time.deltaTime;
    }

    public void Reset()
    {
        Start();
    }
}
