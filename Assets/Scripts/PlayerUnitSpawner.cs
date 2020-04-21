using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSpawner : MonoBehaviour
{
    public PlayerUnit skeleton;
    public PlayerUnit ghost;
    public PlayerUnit butcher;
    public PlayerUnit necroded;

    public GameLogic logic;

    [SerializeField]
    private float necrodedRespawnTime;
    [SerializeField]
    private Vector3 spawnPoint;
    [SerializeField]
    private int skeletonCost;
    [SerializeField]
    private int ghostCost;
    [SerializeField]
    private int butcherCost;

    public void SummonSkeleton()
    {
        if (logic.canSummon && logic.bones >= skeletonCost)
        {
            Instantiate(skeleton, spawnPoint, Quaternion.Euler(Vector3.zero));
            logic.IncreaseResources(-skeletonCost, 0, 0);
            logic.IncreasePlayerArmyCount(1);
        }
    }

    public void SummonGhost()
    {
        if (logic.canSummon && logic.souls >= ghostCost)
        {
            Instantiate(ghost, spawnPoint, Quaternion.Euler(Vector3.zero));
            logic.IncreaseResources(0, -ghostCost, 0);
            logic.IncreasePlayerArmyCount(1);
        }
    }
    public void SummonButcher()
    {
        if (logic.canSummon && logic.fleshes >= butcherCost)
        {
            Instantiate(butcher, spawnPoint, Quaternion.Euler(Vector3.zero));
            logic.IncreaseResources(0, 0, -butcherCost);
            logic.IncreasePlayerArmyCount(1);
        }
    }
    public void SummonNecroded()
    {
        Instantiate(necroded, spawnPoint, Quaternion.Euler(Vector3.zero));
    }

    public void RessurrectNecroded()
    {
        Invoke("SummonNecroded", necrodedRespawnTime);
    }
}
