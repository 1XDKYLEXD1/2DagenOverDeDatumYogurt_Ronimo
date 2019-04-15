using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    [SerializeField] int m_maxhealth;
    [SerializeField] int m_maxdamage;
    [SerializeField] int m_turretattackspeed;

    [SerializeField] List<UnitDataGetter> m_unitdatas;

    float m_cooldowntime;

    void Start()
    {

    }

    void Update()
    {
        if(m_unitdatas.Count > 0)
        {
            m_cooldowntime += Time.deltaTime;

            if(m_cooldowntime > m_turretattackspeed)
            {
                m_unitdatas[0].CurrentHealth -= m_maxdamage;
                if(m_unitdatas[0].CurrentHealth <= 0)
                {
                    m_unitdatas[0].gameObject.SetActive(false);
                    m_unitdatas.Remove(m_unitdatas[0]);
                }
                m_cooldowntime = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            m_unitdatas.Add(collision.gameObject.GetComponent<UnitDataGetter>());
        }
    }
}
