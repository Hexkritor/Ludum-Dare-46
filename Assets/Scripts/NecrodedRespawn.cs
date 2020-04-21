using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecrodedRespawn : MonoBehaviour
{
    void OnDestroy()
    {
        Camera.main.GetComponent<GameLogic>().playerSpawner.RessurrectNecroded();
    }
}
