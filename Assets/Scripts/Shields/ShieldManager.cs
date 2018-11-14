using UnityEngine;

namespace Shields
{
	public class ShieldManager : MonoBehaviour
	{
		[SerializeField] private float m_rotationSpeed = 250.0f;
		private float m_rotationDirection;
		public float m_increasedRotationSpeed = 1.25f;
	
		private void FixedUpdate()
		{
			RotateShields();
		}
	
		private void RotateShields()
		{	
			transform.Rotate(0, 0, m_rotationDirection * m_rotationSpeed * Time.deltaTime);
		}
	
		public void SetRotationDirection(float i)
		{
			m_rotationDirection = i;
		}
	}
}