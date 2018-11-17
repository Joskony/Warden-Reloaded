using System.Collections;
using UnityEngine;

namespace Shields
{
	public class ShieldManager : MonoBehaviour
	{
		[SerializeField] private Shield[] m_shields;
		private bool m_retract;
		private bool m_extend;
		private int m_shieldPositionGauge;
		private const int m_shieldPositionGaugeExtendedThreshold = 25;
		private const int m_shieldPositionGaugeRetractedThreshold = -25;
		public enum ShieldPosition {Default, Extended, Retracted}
		public ShieldPosition m_shieldPosition = ShieldPosition.Default;
		
		[SerializeField] private float m_rotationSpeed = 250.0f;
		private float m_rotationDirection;
		public float m_increasedRotationSpeed = 1.25f;

		private void Update()
		{
			UpdateShieldState();
		}

		private void FixedUpdate()
		{
			RotateShields();
			MoveShields();
		}
	
		private void RotateShields()
		{	
			transform.Rotate(0, 0, m_rotationDirection * m_rotationSpeed * Time.deltaTime);
		}
	
		public void SetRotationDirection(float i)
		{
			m_rotationDirection = i;
		}
		
		private void MoveShields() 
		{
			if (m_shieldPositionGauge >= m_shieldPositionGaugeExtendedThreshold || m_shieldPositionGauge <= m_shieldPositionGaugeRetractedThreshold)
				m_shieldPosition = ShieldPosition.Default;
		
			if (m_shieldPosition == ShieldPosition.Default)
				foreach (Shield shield in m_shields)
					shield.MoveToDefault ();
			else if (m_shieldPosition == ShieldPosition.Extended)
				foreach (Shield shield in m_shields)
					shield.MoveToExtended ();
			else if (m_shieldPosition == ShieldPosition.Retracted)
				foreach (Shield shield in m_shields)
					shield.MoveToRetracted ();
		}
		
		private void UpdateShieldState() 
		{
			if (m_extend && m_shieldPositionGauge != m_shieldPositionGaugeExtendedThreshold) 
			{
				if (m_shieldPosition == ShieldPosition.Default || m_shieldPosition == ShieldPosition.Retracted) 
				{
					m_shieldPosition = ShieldPosition.Extended;
					StartCoroutine (GainExtendedPoints ());
				}
				else if (m_shieldPosition == ShieldPosition.Extended)
					m_shieldPosition = ShieldPosition.Default;

				m_extend = false;
			}
			if (m_retract && m_shieldPositionGauge != m_shieldPositionGaugeRetractedThreshold) 
			{
				if (m_shieldPosition == ShieldPosition.Default || m_shieldPosition == ShieldPosition.Extended) 
				{
					m_shieldPosition = ShieldPosition.Retracted;
					StartCoroutine (GainRetractedPoints ());
				}
				else if (m_shieldPosition == ShieldPosition.Retracted)
					m_shieldPosition = ShieldPosition.Default;

				m_retract = false;
			}
		}

		public void ToggleRetractedState()
		{
			m_retract = !m_retract;
			m_extend = false;
		}

		public void ToggleExtendedState()
		{
			m_retract = false;
			m_extend = !m_extend;
		}

		private IEnumerator GainExtendedPoints() 
		{
			while (m_shieldPositionGauge <= m_shieldPositionGaugeExtendedThreshold && m_shieldPosition == ShieldPosition.Extended) 
			{
				m_shieldPositionGauge++;
				yield return new WaitForSeconds (0.25f);
			}
		}

		private IEnumerator GainRetractedPoints() 
		{
			while (m_shieldPositionGauge >= m_shieldPositionGaugeRetractedThreshold && m_shieldPosition == ShieldPosition.Retracted) 
			{
				m_shieldPositionGauge--;
				yield return new WaitForSeconds (0.25f);
			}
		}
	}
}