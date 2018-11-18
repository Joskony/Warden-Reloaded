using UnityEngine;
 
namespace UI
{
    public class BombInput : MonoBehaviour
    {
        private const float M_MAX_SWIPE_TIME = 0.25f; 
        private const float M_MIN_SWIPE_DISTANCE = 0.15f;
        private const float M_MAX_SWIPE_DISTANCE = 0.3f;
 
        private Vector2 m_startingPosition;
        private float m_startingTime;

        private int m_amountOfBombs = 3;
        [SerializeField] private GameObject m_bomb;
        [SerializeField] private GameObject[] m_bombCharges = new GameObject[3];
		 
        private void Update()
        {   
            if (Input.touches.Length <= 0) return;
 
            foreach (var touch in Input.touches)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    m_startingPosition = new Vector2(touch.position.x / Screen.width, touch.position.y / Screen.width);
                    m_startingTime = Time.time;
                }
 			
                if(touch.phase == TouchPhase.Ended)
                {
                    if (Time.time - m_startingTime > M_MAX_SWIPE_TIME) return;
 
                    Vector2 endingPosition = new Vector2(touch.position.x / Screen.width, touch.position.y / Screen.width);
 
                    Vector2 swipe = new Vector2(endingPosition.x - m_startingPosition.x, endingPosition.y - m_startingPosition.y);
 
                    if (swipe.magnitude < M_MIN_SWIPE_DISTANCE || swipe.magnitude > M_MAX_SWIPE_DISTANCE) return;

                    UseBomb();
                }
            }
        }

        private void UseBomb()
        {
            if (m_amountOfBombs <= 0 || m_bomb.activeSelf) return;
            m_amountOfBombs--;
            m_bombCharges[m_amountOfBombs].SetActive(false);
            m_bomb.SetActive(true);
        }
        
    }
}