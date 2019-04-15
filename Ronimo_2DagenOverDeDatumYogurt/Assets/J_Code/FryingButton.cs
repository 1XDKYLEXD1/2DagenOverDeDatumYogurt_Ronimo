using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.SceneManagement;

enum eButtons
{
    Start=0,
    Options,
    Credits,
    Exit
}

public class FryingButton : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] private Animator m_AnimatorBasket;
    [SerializeField] private Animator m_AnimatorPan;

    [Header("Particles")]

    [SerializeField] private ParticleSystem m_ParticleBurst;

    [Header("Audio")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip a_Sizzle;

    [Header("Buttons")]
    [SerializeField] private eButtons e_Buttons;

    [Header("Panels")]
    [SerializeField] private GameObject m_CreditsPanel;
    [SerializeField] private GameObject m_OptionsPanel;
    [SerializeField] private GameObject m_ButtonsPanel;


    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_CreditsPanel.SetActive(false);
        m_OptionsPanel.SetActive(false);
        m_ButtonsPanel.SetActive(true);
    }
    
    public void BasketDunkStart()
    {
        var emission = m_ParticleBurst.emission;
        emission.enabled = true;
        Debug.Log("Start");
        m_AudioSource.PlayOneShot(a_Sizzle, 1f);
    }
    public void BasketDunkStop()
    {
        var emission = m_ParticleBurst.emission;
        emission.enabled = false;
        Debug.Log("Stop");
    }

    public void OnMouseOver()
    {
        m_AnimatorBasket.SetInteger("State", 1);
        m_AnimatorPan.SetInteger("State", 1);
    }
    private void OnMouseExit()
    {
        m_AnimatorBasket.SetInteger("State", 0);
        m_AnimatorPan.SetInteger("State", 0);
    }

    private void OnMouseDown()
    {
        switch (e_Buttons)
        {
            case eButtons.Start:
                SceneManager.LoadScene(1);
                break;

            case eButtons.Options:
                m_OptionsPanel.SetActive(true);
                m_ButtonsPanel.SetActive(false);
                break;

            case eButtons.Credits:
                m_CreditsPanel.SetActive(true);
                m_ButtonsPanel.SetActive(false);
                break;

            case eButtons.Exit:
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
                break;

            default:
                break;
        }
    }

}

