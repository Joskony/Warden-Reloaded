using System;
using System.Collections;
using System.Collections.Generic;
using Shields;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private ShieldManager m_shieldManager;

    [SerializeField] private GameObject[] m_bombChargesLeft = new GameObject[3];
    [SerializeField] private GameObject[] m_bombChargesRight = new GameObject[3];

    [SerializeField] private Image m_retractedProgress;
    [SerializeField] private Image m_extendedProgress;
    
    private void Update()
    {
        if (m_shieldManager.m_amountOfBombs < 3)
        {
            if (m_bombChargesLeft.Length != 0) m_bombChargesLeft[m_shieldManager.m_amountOfBombs].SetActive(false);
            if (m_bombChargesRight.Length != 0) m_bombChargesRight[m_shieldManager.m_amountOfBombs].SetActive(false);   
        }

        m_retractedProgress.fillAmount = Mathf.Lerp(m_retractedProgress.fillAmount, m_shieldManager.m_shieldRetractedValue / 100.0f, 3 * Time.deltaTime);
        m_extendedProgress.fillAmount = Mathf.Lerp(m_extendedProgress.fillAmount, m_shieldManager.m_shieldExtendedValue / 100.0f, 3 * Time.deltaTime);

        
        //m_retractedProgress.fillAmount = m_shieldManager.m_shieldRetractedValue / 100.0f;
        //m_extendedProgress.fillAmount = m_shieldManager.m_shieldExtendedValue / 100.0f;
    }
}
