using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] UnitCreator m_unitdata;

    void Start()
    {
        
    }

    void Update()
    {
        switch (m_unitdata.m_unittype)
        {
            case UnitCreator.UnitType.Melee:

                break;
        }
    }

    void Move()
    {
        switch (m_unitdata.m_unitteam)
        {
            case UnitCreator.UnitTeam.Player:
                
                break;
        }
    }

    public UnitCreator UnitData
    {
        get
        {
            return m_unitdata;
        }
    }
}
