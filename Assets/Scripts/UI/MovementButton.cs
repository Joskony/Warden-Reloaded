using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class ShieldMovementEvent : UnityEvent<float>{}

public class MovementButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public ShieldManager m_shieldManager;
	
	private ShieldMovementEvent m_shieldMovementEvent;
	private float m_startingRotationDirection;
	public float m_rotationDirection;

	private int m_clickCount;
	private float m_doubleClickInterval = 0.25f;
	private float m_doubleClickRotationSpeedModifier = 1.5f;
	
	private void Start()
	{
		m_startingRotationDirection = m_rotationDirection;
		
		if (m_shieldMovementEvent == null)
			m_shieldMovementEvent = new ShieldMovementEvent();
		
		m_shieldMovementEvent.AddListener(
			delegate
			{
				m_shieldManager.SetRotationDirection(m_rotationDirection);
			}	
		);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		m_rotationDirection = 0;
		m_shieldMovementEvent.Invoke(m_rotationDirection);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		m_clickCount++;

		if (m_clickCount == 1)
		{
			m_rotationDirection = m_startingRotationDirection;
			m_shieldMovementEvent.Invoke(m_rotationDirection);
			StartCoroutine(DoubleClickInterval());
		}
	}

	private IEnumerator DoubleClickInterval()
	{
		yield return new WaitForSeconds(m_doubleClickInterval);

		if (m_clickCount > 1)
		{
			m_rotationDirection = m_startingRotationDirection * m_doubleClickRotationSpeedModifier;
			m_shieldMovementEvent.Invoke(m_rotationDirection);
		}

		yield return new WaitForSeconds(0.05f);
		m_clickCount = 0;
	}
}
