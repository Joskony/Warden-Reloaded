using UnityEngine;

namespace Shields
{
	public class Shield : MonoBehaviour
	{
		private const float M_POSITION_TRANSITION_SPEED = 0.025f;
		
		public Transform m_defaultPosition;
		public Transform m_extendedPosition;
		public Transform m_retractedPosition;

		public void MoveToState(Transform _statePosition)
		{
			transform.position = Vector3.MoveTowards(transform.position, _statePosition.position, M_POSITION_TRANSITION_SPEED);
		}
	}
}