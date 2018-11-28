using UnityEngine;
using _Overhead;

namespace Player
{
	public class Player : MonoBehaviour
	{
		[HideInInspector] public bool isAlive = true;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.gameObject.CompareTag(Tags.M_PROJECTILE_TAG)) return;
			// isAlive = false;
			// gameObject.SetActive(false);
		}
	}
}