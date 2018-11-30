using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Emitter
{
    [Serializable]
    public class EmitterGroups
    {
        public GameObject[] m_Emitter;
    }
    
    public class EmitterManager : MonoBehaviour
    {
        public EmitterGroups[] m_Emitter;
        
        private const float M_ROTATION_CHANGE_DIRECTION_MIN = 3;
        private const float M_ROTATION_CHANGE_DIRECTION_MAX = 8;
        private float m_rotationChangeDirectionTime;

        private int m_ProjectileIndex;
        [SerializeField] private Projectile.Projectile m_Projectile;
        public readonly Projectile.Projectile[] m_ProjectilePool = new Projectile.Projectile[128];

        [NonSerialized] public float m_rotationSpeed = 25;
        [NonSerialized] public float m_projectileSpeed = 2;
        [NonSerialized] public int m_minFireRate = 50;
        [NonSerialized] public int m_maxFireRate = 200;

        [SerializeField] private GameObject m_ProjectileHolder;
        
        private void Start()
        {
            for (int i = 0; i < m_ProjectilePool.Length; i++)
            {
                m_ProjectilePool[i] = Instantiate(m_Projectile, m_ProjectileHolder.transform.position, Quaternion.identity, m_ProjectileHolder.transform);
                m_ProjectilePool[i].gameObject.SetActive(false);
            }
            
            m_rotationChangeDirectionTime = Random.Range(M_ROTATION_CHANGE_DIRECTION_MIN, M_ROTATION_CHANGE_DIRECTION_MAX);
        }

        private void Update()
        {        
            m_rotationChangeDirectionTime -= Time.deltaTime;

            if (!(m_rotationChangeDirectionTime <= 0.0f)) return;
            m_rotationChangeDirectionTime = Random.Range(M_ROTATION_CHANGE_DIRECTION_MIN, M_ROTATION_CHANGE_DIRECTION_MAX);
            ChangeDirection();
        }

        private void FixedUpdate()
        {
            transform.RotateAround(Vector3.zero, Vector3.back, m_rotationSpeed * Time.deltaTime);
        }

        private void ChangeDirection()
        {
            int decider = Random.Range(0, 2);
            if (decider == 0) m_rotationSpeed *= -1;
        }

        private void FireNextProjectile(Transform _emitter)
        {
            if (m_ProjectileIndex == m_ProjectilePool.Length) m_ProjectileIndex = 0;
            m_ProjectilePool[m_ProjectileIndex].m_Speed = m_projectileSpeed;
            m_ProjectilePool[m_ProjectileIndex].gameObject.transform.position = _emitter.position;
            m_ProjectilePool[m_ProjectileIndex].gameObject.SetActive(true);
            m_ProjectileIndex++;
        }

        public IEnumerator StartShootingProjectiles()
        {
            while (true)
            {
                foreach (EmitterGroups emitterGroups in m_Emitter)
                {
                    System.Random random = new System.Random();
                    foreach (int a in Enumerable.Range(0, emitterGroups.m_Emitter.Length).OrderBy(x => random.Next()))
                    {
                        FireNextProjectile(emitterGroups.m_Emitter[a].transform);
                        float nextFire = Random.Range(m_minFireRate, m_maxFireRate);
                        yield return new WaitForSeconds(nextFire / 100);
                    }
                }
            }
        }
    }
}