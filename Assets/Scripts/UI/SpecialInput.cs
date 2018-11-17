using UnityEngine;
using UnityEngine.UI;

using Shields;

namespace UI
{ 
    public class SpecialInput : MonoBehaviour
    {
        [SerializeField] private ShieldManager m_shieldManager;
        [SerializeField] private ShieldManager.ShieldPosition m_shieldPosition;

        private Image m_InputImage;
        
        [SerializeField] private Sprite m_toggleOff;
        [SerializeField] private Sprite m_toggleOn;

        private void Awake()
        {
            m_InputImage = gameObject.GetComponent<Image>();
        }

        private void Update()
        {
            if (m_shieldManager.m_shieldPosition == m_shieldPosition)
            {
                m_InputImage.sprite = m_toggleOn;
            }
            else
            {
                m_InputImage.sprite = m_toggleOff;
            }
        }
    }
}

