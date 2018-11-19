using System.Collections;
using UnityEngine;

namespace Player
{
    public class Bomb : MonoBehaviour
    {
        private const int M_FRAME_COUNT = 45;
        private const float M_INITIAL_SCALE = 0.225f;
        private const float M_TARGET_SCALE = 4.5f;
        private const float M_GROW_TIME = 0.025f;
        private const float M_DELTA_TIME = M_GROW_TIME / M_FRAME_COUNT;
        private const float M_SIZE_INCREASE = (M_TARGET_SCALE - M_INITIAL_SCALE) / M_FRAME_COUNT;
        private float m_currentScale = M_INITIAL_SCALE;
        private bool m_isBombing;

        private void OnEnable()
        {
            m_isBombing = true;
            StartCoroutine(ExecuteBomb());
        }

        private void OnDisable()
        {
            m_isBombing = false;
            m_currentScale = M_INITIAL_SCALE;
            transform.localScale = Vector3.one * m_currentScale;
        }

        private IEnumerator ExecuteBomb()
        {
            while (m_isBombing)
            {
                m_currentScale += M_SIZE_INCREASE;
                if (m_currentScale > M_TARGET_SCALE)
                {
                    m_isBombing = false;
                    m_currentScale = M_TARGET_SCALE;
                }

                transform.localScale = Vector3.one * m_currentScale;
                yield return new WaitForSeconds(M_DELTA_TIME);
            }

            gameObject.SetActive(false);
        }
    }
}