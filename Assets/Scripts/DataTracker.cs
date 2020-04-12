using UnityEngine;

public class DataTracker : MonoBehaviour
{
    private float m_attemptDuration = 0;
    private int m_movementLeftPressed = 0;
    private int m_movementRightPressed = 0;
    private int m_bombButtonsPressed = 0;
    private int m_retractedPressed = 0;
    private int m_extendedPressed = 0;

    public void SetAttemptDuration(float value)
    {
        m_attemptDuration = value;
    }

    public float GetAttemptDuration()
    {
        return m_attemptDuration;
    }

    public void IncrementMovementLeftPressed()
    {
        m_movementLeftPressed++;
    }
    
    public int GetMovementLeftPressed()
    {
        return m_movementLeftPressed;
    }

    public void IncrementMovementRightPressed()
    {
        m_movementRightPressed++;
    }

    public int GetMovementRightPressed()
    {
        return m_movementRightPressed;
    }

    public void IncrementBombButtonsPressed()
    {
        m_bombButtonsPressed++;
    }

    public int GetBombButtonsPressed()
    {
        return m_bombButtonsPressed;
    }

    public void IncrementRetractedPressed()
    {
        m_retractedPressed++;
    }

    public int GetRetractedPressed()
    {
        return m_retractedPressed;
    }

    public void IncrementExtendedPressed()
    {
        m_extendedPressed++;
    }

    public int GetExtendedPressed()
    {
        return m_extendedPressed;
    }
}