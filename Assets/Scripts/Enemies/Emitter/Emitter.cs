using UnityEngine;

namespace Enemies.Emitter
{
    public class Emitter : MonoBehaviour
    {
        [SerializeField] private Projectile.Projectile m_Projectile;
        private readonly Projectile.Projectile[] m_ProjectilePool = new Projectile.Projectile[15];
        private int m_ProjectileIndex;

        private float m_FireRate;
        private const int M_FIRE_RATE_MAX = 1;
        private const int M_FIRE_RATE_MIN = 20;

        [SerializeField] private GameObject m_ProjectileHolder;

        private void Awake()
        {
            for (int i = 0; i < m_ProjectilePool.Length; i++)
            {
                m_ProjectilePool[i] = Instantiate(m_Projectile, m_ProjectileHolder.transform.position, Quaternion.identity, m_ProjectileHolder.transform);
                m_ProjectilePool[i].gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            m_FireRate = Random.Range(M_FIRE_RATE_MIN, M_FIRE_RATE_MAX);
        }

        private void Update()
        {
            if (m_ProjectileIndex == m_ProjectilePool.Length) m_ProjectileIndex = 0;

            if (!(Time.time > m_FireRate)) return;
            FireNextProjectile();
            m_FireRate = Time.time + Random.Range(M_FIRE_RATE_MIN, M_FIRE_RATE_MAX);
        }

        private void FireNextProjectile()
        {
            m_ProjectilePool[m_ProjectileIndex].gameObject.transform.position = transform.position;
            m_ProjectilePool[m_ProjectileIndex].gameObject.SetActive(true);
            m_ProjectileIndex++;
        }
    }
}