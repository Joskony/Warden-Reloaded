using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInput : MonoBehaviour
{
    public GameObject m_bomb;
    private int m_amountOfBombs = 3;
    
    public float m_shakeDetectionThreshold;
    public float m_minShakeInterval;

    private float m_sqrShakeDetectionThreshold;
    private float m_timeSinceLastShake;
    
    // Start is called before the first frame update
    void Start()
    {
        m_sqrShakeDetectionThreshold = Mathf.Pow(m_shakeDetectionThreshold, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= m_sqrShakeDetectionThreshold
            && Time.unscaledTime >= m_timeSinceLastShake + m_minShakeInterval)
        {
            // UseBomb();
            m_timeSinceLastShake = Time.unscaledTime;
        }
    }
    
    private void UseBomb()
    {
        if (m_amountOfBombs <= 0 || m_bomb.activeSelf) return;
        m_amountOfBombs--;
        // m_bombCharges[m_amountOfBombs].SetActive(false);
        m_bomb.SetActive(true);
    }
}
