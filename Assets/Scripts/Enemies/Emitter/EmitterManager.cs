using UnityEngine;

namespace Enemies.Emitter
{
    public class EmitterManager : MonoBehaviour
    {
        private readonly Vector3 m_rotationTarget = Vector3.zero;
        // ReSharper disable once InconsistentNaming
        private const float m_rotationChangeDirectionMin = 3;
        private const float m_rotationChangeDirectionMax = 8;
        private float m_rotationChangeDirectionTime;
        private float m_rotationSpeed = 25;

        private void Start()
        {
            m_rotationChangeDirectionTime = Random.Range(m_rotationChangeDirectionMin, m_rotationChangeDirectionMax);
        }

        private void Update()
        {
            m_rotationChangeDirectionTime -= Time.deltaTime;

            if (!(m_rotationChangeDirectionTime <= 0.0f)) return;
            m_rotationChangeDirectionTime = Random.Range(m_rotationChangeDirectionMin, m_rotationChangeDirectionMax);
            ChangeDirection();
        }

        private void FixedUpdate()
        {
            transform.RotateAround(m_rotationTarget, Vector3.back, m_rotationSpeed * Time.deltaTime);
        }

        private void ChangeDirection()
        {
            var decider = Random.Range(0, 2);
            if (decider == 0) m_rotationSpeed *= -1;
        }
    }
}
