using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class ShieldMovementEvent : UnityEvent<float>{}

public class MovementButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public ShieldManager m_shieldManager;
	
	public float m_rotationDirection;
	private ShieldMovementEvent m_shieldMovementEvent;
	private float m_startingRotationDirection;

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
		Debug.Log("Up!");
	}

	public void OnPointerDown(PointerEventData eventData)
	{	
		m_rotationDirection = m_startingRotationDirection;
		m_shieldMovementEvent.Invoke(m_rotationDirection);
		Debug.Log("Turn!");
	}
}
