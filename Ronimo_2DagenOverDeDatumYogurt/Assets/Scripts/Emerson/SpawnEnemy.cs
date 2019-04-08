using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnEnemy : MonoBehaviour
{
    public Button m_SpawnEnemy;
    public Button m_SpawnEnemy2;

    public int speed;

    public int m_Money = 500;

    public GameObject m_Spawnpoint;
    public GameObject m_Enemy1;
    public GameObject m_Enemy2;

    [SerializeField]
    private TMP_Text m_uiText;

    public void Start()
    {
        
        m_SpawnEnemy.onClick.AddListener(spawnEnemy1);
        m_SpawnEnemy2.onClick.AddListener(spawnEnemy2);
        
    }

    private void spawnEnemy1()
    {
        if (m_Money >= 200 && m_SpawnEnemy)
        {
            Instantiate(m_Enemy1, m_Spawnpoint.transform.position, m_Spawnpoint.transform.rotation);
            m_Money -= 200;
            Debug.Log(m_Enemy1);
        }
        else if (m_Money < 200)
        {
            Debug.Log("insufficient funds");
        }
        
    }
    private void spawnEnemy2()
    {
        if (m_Money >= 200 && m_SpawnEnemy2)
        {
            Instantiate(m_Enemy2, m_Spawnpoint.transform.position, m_Spawnpoint.transform.rotation);
            m_Money -= 200;
            Debug.Log(m_Enemy2);
        }
        else if (m_Money < 200)
        {
            Debug.Log("insufficient funds");
        }

    }
    public void Update()
    {
        m_Enemy2.transform.position += transform.right * -speed * Time.deltaTime;
        m_Enemy1.transform.position += transform.right * -speed * Time.deltaTime;
        m_uiText.text = m_Money.ToString();

    }
}
