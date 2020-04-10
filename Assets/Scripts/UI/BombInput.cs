using Shields;
using TMPro;
using UnityEngine;
 
namespace UI
{
    public class BombInput : MonoBehaviour
    {
        [SerializeField] private ShieldManager m_shieldManager;
        
        private Vector2 m_startingPosition;
        private float m_startingTime;

        [SerializeField] private GameObject m_bomb;
        
        public void UseBomb()
        {
            if (m_shieldManager.m_amountOfBombs <= 0 || m_bomb.activeSelf) return;
            m_shieldManager.m_amountOfBombs--;
            m_bomb.SetActive(true);
        }
        
    }
}