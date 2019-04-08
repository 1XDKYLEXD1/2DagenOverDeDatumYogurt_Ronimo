using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnitEditWindow : EditorWindow
{
    enum UnitType
    {
        Spellcaster,
        Miner,
        Archer,
        Melee,
        Tank
    };

    string m_unitname;
    int m_worthkilling;
    int m_health;
    float m_movementspeed;
    float m_damageamount;
    int m_buildcost;
    UnitType m_unittype;

    [MenuItem("Window/Unit Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        UnitEditWindow window = (UnitEditWindow)EditorWindow.GetWindow(typeof(UnitEditWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Unit Settings", EditorStyles.boldLabel);

        m_unitname = EditorGUILayout.TextField("Unit Name", m_unitname);
        EditorGUILayout.LabelField("Important Data");
        m_health = EditorGUILayout.IntField("Unit Health", m_health);
        m_movementspeed = EditorGUILayout.FloatField("Unit Speed", m_movementspeed);
        m_damageamount = EditorGUILayout.FloatField("Unit Damage", m_damageamount);
        m_buildcost = EditorGUILayout.IntField("Unit Build Cost", m_buildcost);
        m_worthkilling = EditorGUILayout.IntField("Unit Kill Award", m_worthkilling);
        m_unittype = (UnitType)EditorGUILayout.EnumPopup("Unit Type", m_unittype);

        if(GUILayout.Button("Create Unit"))
        {
            CreateScriptableObject();
        }
    }

    void CreateScriptableObject()
    {
        //CreateAssetMenuAttribute menuattribute = new CreateAssetMenuAttribute();

        UnitCreator obj = ScriptableObject.CreateInstance<UnitCreator>();
        obj.m_unitname = m_unitname;
        obj.m_health = m_health;
        obj.m_movementspeed = m_movementspeed;
        obj.m_damageamount = m_damageamount;
        obj.m_buildcost = m_buildcost;
        obj.m_worthkilling = m_worthkilling;
        obj.m_unittype = (UnitCreator.UnitType)m_unittype;
    }
}