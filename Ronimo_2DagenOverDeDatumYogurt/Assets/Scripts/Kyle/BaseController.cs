using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] Transform m_unitspawnpoint;
    int m_currentgold;

    void Start()
    {
        m_currentgold = 100;
    }

    void Update()
    {
        
    }

    public void SpawnUnit(GameObject unit)
    {
        if(unit.GetComponent<UnitController>().UnitData.m_buildcost <= m_currentgold)
        {
            Instantiate(unit);
        }
        else
        {
            Debug.Log("That unit is to expenisve");
        }
    }
}
