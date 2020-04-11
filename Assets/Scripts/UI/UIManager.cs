using System;
using System.Collections;
using System.Collections.Generic;
using Shields;
using TMPro;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private ShieldManager m_shieldManager;

    [SerializeField] private GameObject[] m_bombChargesLeft = new GameObject[3];
    [SerializeField] private GameObject[] m_bombChargesRight = new GameObject[3];
    
    private void Update()
    {
        if (m_shieldManager.m_amountOfBombs < 3)
        {
            if (m_bombChargesLeft.Length != 0) m_bombChargesLeft[m_shieldManager.m_amountOfBombs].SetActive(false);
            if (m_bombChargesRight.Length != 0) m_bombChargesRight[m_shieldManager.m_amountOfBombs].SetActive(false);   
        }
    }
}
