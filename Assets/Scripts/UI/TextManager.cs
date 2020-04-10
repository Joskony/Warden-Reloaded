using System;
using System.Collections;
using System.Collections.Generic;
using Shields;
using TMPro;
using UI;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    [SerializeField] private ShieldManager m_shieldManager;
    
    [SerializeField] private List<TextMeshProUGUI> m_bombTexts;
    [SerializeField] private TextMeshProUGUI m_RetractedText;
    [SerializeField] private TextMeshProUGUI m_ExtendedText;

    private void Update()
    {
        foreach (var bombText in m_bombTexts)
        {
            bombText.text = m_shieldManager.m_amountOfBombs.ToString();
        }

        if (m_RetractedText != null) m_RetractedText.text = m_shieldManager.m_shieldRetractedValue + "%";
        if (m_ExtendedText != null) m_ExtendedText.text = m_shieldManager.m_shieldExtendedValue + "%";
    }
}
