using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _Units;

    [SerializeField]
    private GameObject _SpawnPoint;

    private float _Timer;
    private int _Index;
    private int _SpawnCount;

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
                    if(_SpawnCount < 3)
                    {
                        Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                        _SpawnCount += 1;
                    }                   
                    else if(_SpawnCount >= 3)
                    {
                        _Index = 2;
                        _SpawnCount = 0;
                    }
                    break;
                case UnitCreator.UnitType.Archer:
                    Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                    _Index = 3;
                    break;
                case UnitCreator.UnitType.Miner:
                    Instantiate(_Units[_Index], _SpawnPoint.transform.position, Quaternion.identity);
                    _Index = 0;
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
