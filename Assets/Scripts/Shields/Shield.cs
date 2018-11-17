using UnityEngine;

public class Shield : MonoBehaviour
{

	private float m_positionTransitionSpeed = 0.05f;
	[SerializeField] private Transform m_defaultPosition;
	[SerializeField] private Transform m_extendedPosition;
	[SerializeField] private Transform m_retractedPosition;
	
	public void MoveToDefault() {
	
		transform.position = Vector3.MoveTowards (transform.position, m_defaultPosition.position, m_positionTransitionSpeed);

	}

	public void MoveToExtended() {

		transform.position = Vector3.MoveTowards (transform.position, m_extendedPosition.position, m_positionTransitionSpeed);

	}

	public void MoveToRetracted() {

		transform.position = Vector3.MoveTowards (transform.position, m_retractedPosition.position, m_positionTransitionSpeed);

	}

}
