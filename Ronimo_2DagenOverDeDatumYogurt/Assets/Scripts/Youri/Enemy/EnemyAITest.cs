using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITest : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _Units;

    [SerializeField]
    private GameObject _SpawnPoint;

    private float _Timer;
    private int _Index;
    private int _SpawnCount;

    private List<UnitCreator.UnitType> _SpawnOrder = new List<UnitCreator.UnitType>
    {
        UnitCreator.UnitType.Tank,
        UnitCreator.UnitType.Melee,
        UnitCreator.UnitType.Archer,
        UnitCreator.UnitType.Spellcaster,
        UnitCreator.UnitType.Miner
    };

    [SerializeField]
    private float _TimeUntillSpawn;

    void Start()
    {
        _SpawnCount = 0;
        _Timer = 0;
        _Index = 0;
    }

    void Update()
    {
        _Timer += Time.deltaTime;

        if (_Timer >= _TimeUntillSpawn)
        {
            SpawnUnit();
            _Timer = 0;
        }
    }

    private bool SpawnUnit(UnitCreator.UnitType type)
    {
        GameObject unitObject = _Units[(int)type];
        UnitDataGetter unitController = unitObject.GetComponent<UnitDataGetter>();

        UnitCreator.UnitType unitType = unitController.UnitData.m_unittype;
        if (type != unitType)
        {
            Debug.Log("Cannot spawn unit: the unit type and unity object do not match!");
            return false;
        }

        if (unitController == null)
        {
            Debug.Log("Cannot spawn unit: no unit controller was found!");
            return false;
        }

        Instantiate(unitObject, _SpawnPoint.transform.position, Quaternion.identity);

        return true;
    }

    private void SpawnUnit()
    {
        UnitCreator.UnitType unitType = _SpawnOrder[_Index];
        int spawnAmount = 1;

        switch (unitType)
        {
            case UnitCreator.UnitType.Melee:
                spawnAmount = 3;
                break;
        }

        if (_SpawnCount < spawnAmount)
        {
            SpawnUnit(unitType);
            _SpawnCount++;
        }
        if (_SpawnCount >= spawnAmount)
        {
            _SpawnCount = 0;
            _Index++;
        }

        _Index = _Index % _SpawnOrder.Count;
    }
}
