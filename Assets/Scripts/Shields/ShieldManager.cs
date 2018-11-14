using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{

	[SerializeField] private float m_rotationSpeed = 250.0f;
	public float m_rotationDirection;

	private void FixedUpdate()
	{
		ControlShields();
	}

	private void ControlShields()
	{
		float rotationDir = m_rotationDirection * m_rotationSpeed;
		rotationDir *= Time.deltaTime;
		transform.Rotate(0, 0, rotationDir);
	}

	public void SetRotationDirection(float i)
	{
		m_rotationDirection = i;
	}
}
