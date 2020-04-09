using TMPro;
using UnityEngine;
 
namespace UI
{
    public class BombInput : MonoBehaviour
    {
        private Vector2 m_startingPosition;
        private float m_startingTime;

        private int m_amountOfBombs = 3;
        [SerializeField] private GameObject m_bomb;
        [SerializeField] private TextMeshProUGUI m_bombText;
        
        public void UseBomb()
        {
            if (m_amountOfBombs <= 0 || m_bomb.activeSelf) return;
            m_amountOfBombs--;
            m_bombText.text = m_amountOfBombs.ToString();
            m_bomb.SetActive(true);
        }
        
    }
}