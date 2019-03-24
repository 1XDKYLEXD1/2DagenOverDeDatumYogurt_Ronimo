using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AUnit", menuName = "Units/Create Unit")]
public class UnitCreator : ScriptableObject
{
    public enum UnitType
    {
        Spellcaster,
        Miner,
        Archer,
        Melee,
        Tank
    };

    public string m_unitname;
    public int m_worthkilling;
    public int m_health;
    public float m_movementspeed;
    public float m_damageamount;
    public int m_buildcost;
    public UnitType m_unittype;
}
