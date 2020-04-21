using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitRemoveCounder : MonoBehaviour
{
    void OnDestroy()
    {
        Camera.main.GetComponent<GameLogic>().IncreasePlayerArmyCount(-1);
    }
}
