using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject m_Sprite;
    [SerializeField] GameObject m_MainPanel;
    [SerializeField] GameObject m_Panel;

    private void OnMouseOver()
    {
        m_Sprite.SetActive(true);
    }
    private void OnMouseExit()
    {
        m_Sprite.SetActive(false);
    }

    private void OnMouseDown()
    {
        m_Panel.SetActive(false);
        m_MainPanel.SetActive(true);
    }
}
