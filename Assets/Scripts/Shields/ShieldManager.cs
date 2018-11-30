using System;
using System.Collections;
using UnityEngine;

namespace Shields
{
	public class ShieldManager : MonoBehaviour
	{
		private Shield[] m_shields;
		
		private bool m_retractInput;
		private bool m_extendInput;
		
		[NonSerialized] public int m_shieldPositionGauge;
		private const float M_GAUGE_CHARGE_SPEED = 0.25f;
		private const int M_SHIELD_POSITION_GAUGE_EXTENDED_THRESHOLD = 25;
		private const int M_SHIELD_POSITION_GAUGE_RETRACTED_THRESHOLD = -25;
		
		public enum ShieldPosition {Default, Extended, Retracted}
		[NonSerialized] public ShieldPosition m_shieldPosition = ShieldPosition.Default;

		private float m_rotationDirection;
		private const float M_ROTATION_SPEED = 250.0f;
		public readonly float m_increasedRotationSpeed = 1.25f;

		private void Awake()
		{
			m_shields = GetComponentsInChildren<Shield>();
		}

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
			transform.Rotate(0, 0, m_rotationDirection * M_ROTATION_SPEED * Time.deltaTime);
		}
	
		public void SetRotationDirection(float _i)
		{
			m_rotationDirection = _i;
		}
		
		private void MoveShields() 
		{
			if (m_shieldPositionGauge >= M_SHIELD_POSITION_GAUGE_EXTENDED_THRESHOLD || m_shieldPositionGauge <= M_SHIELD_POSITION_GAUGE_RETRACTED_THRESHOLD)
				m_shieldPosition = ShieldPosition.Default;
		
			if (m_shieldPosition == ShieldPosition.Default)
				foreach (Shield shield in m_shields)
					shield.MoveToState(shield.m_defaultPosition);
			else if (m_shieldPosition == ShieldPosition.Extended)
				foreach (Shield shield in m_shields)
					shield.MoveToState(shield.m_extendedPosition);
			else if (m_shieldPosition == ShieldPosition.Retracted)
				foreach (Shield shield in m_shields)
					shield.MoveToState(shield.m_retractedPosition);
		}
		
		private void UpdateShieldState() 
		{
			if (m_extendInput && m_shieldPositionGauge != M_SHIELD_POSITION_GAUGE_EXTENDED_THRESHOLD) 
			{
				if (m_shieldPosition == ShieldPosition.Default || m_shieldPosition == ShieldPosition.Retracted) 
				{
					m_shieldPosition = ShieldPosition.Extended;
					StartCoroutine (GainExtendedPoints ());
				}
				else if (m_shieldPosition == ShieldPosition.Extended)
					m_shieldPosition = ShieldPosition.Default;

				m_extendInput = false;
			}
			if (m_retractInput && m_shieldPositionGauge != M_SHIELD_POSITION_GAUGE_RETRACTED_THRESHOLD) 
			{
				if (m_shieldPosition == ShieldPosition.Default || m_shieldPosition == ShieldPosition.Extended) 
				{
					m_shieldPosition = ShieldPosition.Retracted;
					StartCoroutine (GainRetractedPoints ());
				}
				else if (m_shieldPosition == ShieldPosition.Retracted)
					m_shieldPosition = ShieldPosition.Default;

				m_retractInput = false;
			}
		}

		public void ToggleExtendedState()
		{
			m_retractInput = false;
			m_extendInput = !m_extendInput;
		}
		
		public void ToggleRetractedState()
		{
			m_retractInput = !m_retractInput;
			m_extendInput = false;
		}

		private IEnumerator GainExtendedPoints() 
		{
			while (m_shieldPositionGauge <= M_SHIELD_POSITION_GAUGE_EXTENDED_THRESHOLD && m_shieldPosition == ShieldPosition.Extended) 
			{
				m_shieldPositionGauge++;
				yield return new WaitForSeconds (M_GAUGE_CHARGE_SPEED);
			}
		}

		private IEnumerator GainRetractedPoints() 
		{
			while (m_shieldPositionGauge >= M_SHIELD_POSITION_GAUGE_RETRACTED_THRESHOLD && m_shieldPosition == ShieldPosition.Retracted) 
			{
				m_shieldPositionGauge--;
				yield return new WaitForSeconds (M_GAUGE_CHARGE_SPEED);
			}
		}
	}
}