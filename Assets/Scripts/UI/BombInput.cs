using System;
using Shields;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BombInput : MonoBehaviour
    {
        [SerializeField] private ShieldManager m_shieldManager;
        
        private Image m_InputImage;
        
        [SerializeField] private Sprite m_toggleOff;
        [SerializeField] private Sprite m_toggleOn;
        
        private Vector2 m_startingPosition;
        private float m_startingTime;
        
        [SerializeField] private GameObject m_bomb;

        [SerializeField] private GameObject[] m_bombCharges = new GameObject[3];
        
        private void Awake()
        {
            m_InputImage = gameObject.GetComponent<Image>();
        }
        
        private void Update()
        {
            if (m_bomb.activeSelf)
            {
                m_InputImage.sprite = m_toggleOn;
            }
            else
            {
                m_InputImage.sprite = m_toggleOff;
            }
        }

        public void UseBomb()
        {
            if (m_shieldManager.m_amountOfBombs <= 0 || m_bomb.activeSelf) return;
            m_shieldManager.m_amountOfBombs--;
            if (m_bombCharges.Length != 0) m_bombCharges[m_shieldManager.m_amountOfBombs].SetActive(false);
            m_bomb.SetActive(true);
        }

    }
}