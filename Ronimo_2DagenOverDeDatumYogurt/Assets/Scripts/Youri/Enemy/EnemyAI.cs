using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _Units;

    [SerializeField]
    private GameObject _SpawnPoint, _MinerUnit;

    private float _Timer;
    private int _Index;
    private int _MeleeSpawnCount;

    [SerializeField]
    private float _TimeUntillSpawn;

    void Start()
    {
        _MeleeSpawnCount = 0;
        _Timer = 0;
        _Index = 0;

        for(int i = 0; i < 2; i++)
        {
            Instantiate(_MinerUnit, _SpawnPoint.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        _Timer += Time.deltaTime;

        if(_Timer >= _TimeUntillSpawn)
        {
            SpawnUnit();
            _Timer = 0;
        }
    }

    private void SpawnUnit()
    {
        UnitDataGetter udg = _Units[_Index].GetComponent<UnitDataGetter>();
        UnitCreator.UnitType unitType = udg.UnitData.m_unittype;
        
        if(udg != null)
        {
            switch (unitType)
            {
                case UnitCreator.UnitType.Melee:
                    if(_MeleeSpawnCount < 3)
                    {
                        Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                        _MeleeSpawnCount += 1;
                    }                   
                    else if(_MeleeSpawnCount >= 3)
                    {
                        _Index = 2;
                        _MeleeSpawnCount = 0;
                    }
                    break;
                case UnitCreator.UnitType.Archer:
                    Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                    _Index = 3;
                    break;
                case UnitCreator.UnitType.Spellcaster:
                    Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                    _Index = 0;
                    break;
                case UnitCreator.UnitType.Tank:
                    Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                    _Index = 1;
                    break;
            }
        }
        else if(udg == null)
        {
            Debug.Log("Unit Creator Script Is Null");
        }
        
    }
}
