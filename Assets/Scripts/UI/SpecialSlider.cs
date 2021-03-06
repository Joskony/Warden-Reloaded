﻿using UnityEngine;
using UnityEngine.UI;
using Shields;

namespace UI
{
    public class SpecialSlider : MonoBehaviour
    {
        [SerializeField] private ShieldManager m_shieldManager;
        private Slider m_slider;

        private const int M_SLIDER_FILL_SPEED = 3;

        private void Awake()
        {
            m_slider = GetComponent<Slider>();
        }

        private void Update()
        {
            m_slider.value = Mathf.Lerp(m_slider.value, m_shieldManager.m_shieldPositionGauge, M_SLIDER_FILL_SPEED * Time.deltaTime);
        }
    }
}