using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{

    public TextMeshProUGUI bonesText;
    public TextMeshProUGUI soulsText;
    public TextMeshProUGUI fleshText;
    public TextMeshProUGUI playerArmyCountText;
    public TextMeshProUGUI enemyArmyCountText;
    public TextMeshProUGUI liveCountText;
    public TextMeshProUGUI dayCountText;
    public GameObject summonPanel;
    public GameObject dayButton;

    public PlayerUnitSpawner playerSpawner;
    public EnemySpawner enemySpawner;

    public Vector3Int[] days;

    [SerializeField]
    private int cryptLife;
    [SerializeField]
    private int _playerArmyLimit;
    private int _playerArmyCount;

    private int _enemyArmyCount;
    private int _bones;
    private int _souls;
    private int _fleshes;
    private int _day;

    public int bones { get { return _bones; } }
    public int souls { get { return _souls; } }
    public int fleshes { get { return _fleshes; } }
    public bool canSummon { get { return _playerArmyCount < _playerArmyLimit; } }


    // Start is called before the first frame update
    void Start()
    {
        _playerArmyCount = 0;
        _bones = _souls = _fleshes = _day = 0;
        if (enemySpawner)
            enemySpawner.enabled = false;
        if (summonPanel)
            summonPanel.SetActive(true);
    }

    public void IncreaseResources(int bone, int soul, int flesh)
    {
        _bones += bone;
        _souls += soul;
        _fleshes += flesh;
    }

    public void IncreasePlayerArmyCount(int value)
    {
        _playerArmyCount += value;
    }

    public void IncreaseEnemyArmyCount(int value)
    {
        _enemyArmyCount += value;
        if (_enemyArmyCount == 0)
            EndDay();
    }

    public void IncreaseCryptLife(int value)
    {
        cryptLife += value;
    }

    public void StartDay()
    {
        if (enemySpawner)
        {
            enemySpawner.enabled = true;
            enemySpawner.Reset();
            enemySpawner.daySpawnLimit = days[_day];
        }
        if (summonPanel)
            summonPanel.SetActive(false);
        if (dayButton)
            dayButton.SetActive(false);
        _enemyArmyCount = days[_day].x + days[_day].y + days[_day].z;
    }

    public void EndDay()
    {
        ++_day;
        if (enemySpawner) 
        {
            enemySpawner.enabled = false;
        }
        if (summonPanel)
            summonPanel.SetActive(true);
        if (dayButton)
            dayButton.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bonesText.text = _bones.ToString();
        soulsText.text = _souls.ToString();
        fleshText.text = _fleshes.ToString();
        playerArmyCountText.text = string.Format("{0}/{1}",_playerArmyCount,_playerArmyLimit);
        enemyArmyCountText.text = string.Format("{0}", _enemyArmyCount);
        dayCountText.text = string.Format("Day {0}", _day + 1);
        liveCountText.text = string.Format("{0}", cryptLife);
    }
}
