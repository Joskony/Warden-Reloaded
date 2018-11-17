using UnityEngine;

namespace Shields
{
	public class Shield : MonoBehaviour
	{
		private const float M_POSITION_TRANSITION_SPEED = 0.025f;
		[SerializeField] private Transform m_defaultPosition;
		[SerializeField] private Transform m_extendedPosition;
		[SerializeField] private Transform m_retractedPosition;
		
		public void MoveToDefault() 
		{
			transform.position = Vector3.MoveTowards (transform.position, m_defaultPosition.position, M_POSITION_TRANSITION_SPEED);
		}
	
		public void MoveToExtended() 
		{
			transform.position = Vector3.MoveTowards (transform.position, m_extendedPosition.position, M_POSITION_TRANSITION_SPEED);
		}
	
		public void MoveToRetracted() 
		{
			transform.position = Vector3.MoveTowards (transform.position, m_retractedPosition.position, M_POSITION_TRANSITION_SPEED);
		}
	}
}