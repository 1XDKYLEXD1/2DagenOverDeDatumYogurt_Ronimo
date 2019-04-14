using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataGetter : MonoBehaviour
{
    [SerializeField] UnitCreator m_unitdata;

    int m_currenthealth;

    void Start()
    {
        m_currenthealth = m_unitdata.m_health;    
    }

    public UnitCreator UnitData
    {
        get
        {
            return m_unitdata;
        }
    }

    public int CurrentHealth
    {
        get { return m_currenthealth; }
        set { m_currenthealth = (int)value; }
    }
}
