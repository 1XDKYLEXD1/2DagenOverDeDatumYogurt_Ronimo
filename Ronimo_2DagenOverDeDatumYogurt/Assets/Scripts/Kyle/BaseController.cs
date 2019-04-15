using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] Transform m_unitspawnpointplayer;
    [SerializeField] Transform m_minerunitspawnpointplayer;
    [SerializeField] int m_startinggold;
    int m_currentgold;

    void Start()
    {
        m_currentgold = m_startinggold;
    }

    public void SpawnUnit(GameObject unit)
    {
        UnitCreator unitdataobj = unit.GetComponent<UnitDataGetter>().UnitData;

        if (unitdataobj.m_buildcost <= m_currentgold)
        {
            Instantiate(unit);
            if(unitdataobj.m_unittype == UnitCreator.UnitType.Miner)
            {
                unit.transform.position = m_minerunitspawnpointplayer.position;
            }
            else
            {
                unit.transform.position = m_unitspawnpointplayer.position;
            }
            m_currentgold -= unitdataobj.m_buildcost;
        }
        else
        {
            Debug.Log("That unit is to expenisve");
        }
    }
}
