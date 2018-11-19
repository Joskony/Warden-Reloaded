using UnityEngine;

using _Overhead;

namespace Enemies.Projectile
{
    public class Projectile : MonoBehaviour
    {
        private const float m_Speed = 2f;

        private readonly Vector3 m_Target = Vector3.zero;

        private void Update()
        {
            if (transform.position == m_Target)
                gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            float step = m_Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, m_Target, step);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.M_BLOCKER_TAG) || other.gameObject.CompareTag(Tags.M_PLAYER_TAG) || other.gameObject.CompareTag(Tags.M_PROJECTILE_TAG))
                gameObject.SetActive(false);
        }
    }
}
