using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataGetter : MonoBehaviour
{
    [SerializeField] UnitCreator m_unitdata;

    public UnitCreator UnitData
    {
        get
        {
            return m_unitdata;
        }
    }
}
