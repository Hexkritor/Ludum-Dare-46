using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public Waypoint startPoint;

    [SerializeField]
    private float _spawnDelay;
    private float _spawnCooldown;

    void Start()
    {
        _spawnCooldown = _spawnDelay;
    }

    void Update()
    {
        if (_spawnCooldown <= 0)
        {
            Enemy e = Instantiate(enemy, startPoint.transform.position, Quaternion.Euler(Vector3.zero));
            e.SetWaypoint(startPoint);
            _spawnCooldown = _spawnDelay;
        }
        _spawnCooldown -= Time.deltaTime;
    }
    
}
