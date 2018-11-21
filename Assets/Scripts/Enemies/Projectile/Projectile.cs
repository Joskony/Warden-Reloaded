﻿using UnityEngine;

using _Overhead;

namespace Enemies.Projectile
{
    public class Projectile : MonoBehaviour
    {
        private const float m_Speed = 2f;

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector3.zero, m_Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.M_BLOCKER_TAG) || other.gameObject.CompareTag(Tags.M_PLAYER_TAG) || other.gameObject.CompareTag(Tags.M_PROJECTILE_TAG))
                gameObject.SetActive(false);
        }
    }
}