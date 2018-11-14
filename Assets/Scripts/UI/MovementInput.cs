using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using Shields;

namespace UI
{
	[System.Serializable]
	public class ShieldMovementEvent : UnityEvent<float> { }

	public class MovementInput : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		public ShieldManager m_shieldManager;

		[SerializeField] private float m_rotationDirection;
		private float m_startingRotationDirection;
		private ShieldMovementEvent m_shieldMovementEvent;

		private const float M_DOUBLE_CLICK_INTERVAL = 0.25f;
		private float m_lastClick;

		private void Start()
		{
			m_startingRotationDirection = m_rotationDirection;

			if (m_shieldMovementEvent == null)
				m_shieldMovementEvent = new ShieldMovementEvent();

			m_shieldMovementEvent.AddListener(
				delegate { m_shieldManager.SetRotationDirection(m_rotationDirection); }
			);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			m_rotationDirection = 0;
			m_shieldMovementEvent.Invoke(m_rotationDirection);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (m_lastClick + M_DOUBLE_CLICK_INTERVAL > Time.time)
				m_rotationDirection = m_startingRotationDirection * m_shieldManager.m_increasedRotationSpeed;
			else
			{
				m_lastClick = Time.time;
				m_rotationDirection = m_startingRotationDirection;
			}

			m_shieldMovementEvent.Invoke(m_rotationDirection);
		}
	}
}