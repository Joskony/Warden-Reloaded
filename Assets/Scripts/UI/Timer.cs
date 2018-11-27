using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_currentTimeText;
        [SerializeField] private TextMeshProUGUI m_bestTimeText;

        [SerializeField] private GameManager m_gameManager;

        private void Update()
        {
            m_currentTimeText.text = FormatTime(m_gameManager.m_currentGameTime);
            m_bestTimeText.text = FormatTime(m_gameManager.m_bestGameTime);
        }

        private static string FormatTime(float _time)
        {
            int initialTime = (int) _time;
            int minutes = initialTime / 60;
            int seconds = initialTime % 60;
            float milliseconds = _time * 1000 % 1000;
            return $"{minutes:00}:{seconds:00}:{milliseconds:000}";
        }
    }
}