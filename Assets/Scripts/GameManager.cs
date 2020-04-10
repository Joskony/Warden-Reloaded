using System;
using System.Collections;
using Enemies.Emitter;
using Enemies.Projectile;
using UnityEngine;
using UnityEngine.SceneManagement;
using _Overhead;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player.Player m_player;
    [SerializeField] private EmitterManager m_emitterManager;

    [SerializeField] private GameObject m_inputBlockingPanel;

    private const float M_GAME_START_DELAY = 1f;
    private const float M_GAME_END_DELAY = 1f;

    private Coroutine m_emitterShootingRoutine;

    private float m_initialTime;
    [NonSerialized] public float m_currentGameTime;
    [NonSerialized] public float m_bestGameTime;

    private const int M_FIRST_DIFFICULTY_INTERVAL = 15;
    private const int M_SECOND_DIFFICULTY_INTERVAL = 30;
    private const int M_THIRD_DIFFICULTY_INTERVAL = 60;

    private const float M_ROTATION_SPEED_INCREASE = 2.5f;
    private const float M_PROJECTILE_SPEED_INCREASE = 0.2f;
    private const int M_FIRE_RATE_DECREASE_MIN = 10;
    private const int M_FIRE_RATE_DECREASE_MAX = 10;

    private void Start()
    {
        m_bestGameTime = PlayerPrefs.GetFloat(Tags.M_HIGHSCORE_STRING, m_bestGameTime);
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GameRunning());
        yield return StartCoroutine(GameEnding());
    }
    
    private IEnumerator GameStarting()
    {
        yield return new WaitForSeconds(M_GAME_START_DELAY);
        m_emitterShootingRoutine = StartCoroutine(m_emitterManager.StartShootingProjectiles());
    }

    private IEnumerator GameRunning()
    {
        m_initialTime = Time.time;
        
        InvokeRepeating(nameof(IncreaseRotationSpeed), M_FIRST_DIFFICULTY_INTERVAL, M_FIRST_DIFFICULTY_INTERVAL);
        InvokeRepeating(nameof(IncreaseProjectileSpeed), M_SECOND_DIFFICULTY_INTERVAL, M_SECOND_DIFFICULTY_INTERVAL);
        InvokeRepeating(nameof(IncreaseFireRate), M_THIRD_DIFFICULTY_INTERVAL, M_THIRD_DIFFICULTY_INTERVAL);
        
        while (m_player.isAlive)
        {
            m_currentGameTime = Time.time - m_initialTime;
            if (m_bestGameTime <= m_currentGameTime)
                m_bestGameTime = m_currentGameTime;
            yield return null;
        }
    }

    private IEnumerator GameEnding()
    {
        CancelInvoke();
        StopCoroutine(m_emitterShootingRoutine);
        m_inputBlockingPanel.SetActive(true);
        foreach (Projectile projectile in m_emitterManager.m_ProjectilePool)
            projectile.gameObject.SetActive(false);
        m_emitterManager.m_rotationSpeed = 0;
        PlayerPrefs.SetFloat(Tags.M_HIGHSCORE_STRING, m_bestGameTime);
        yield return new WaitForSeconds(M_GAME_END_DELAY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void IncreaseRotationSpeed()
    {
        m_emitterManager.m_rotationSpeed += Mathf.Sign(m_emitterManager.m_rotationSpeed) * M_ROTATION_SPEED_INCREASE;
    }

    public void IncreaseProjectileSpeed()
    {
        m_emitterManager.m_projectileSpeed += M_PROJECTILE_SPEED_INCREASE;
    }

    public void IncreaseFireRate()
    {
        if (m_emitterManager.m_minFireRate >= 0)
            m_emitterManager.m_minFireRate -= M_FIRE_RATE_DECREASE_MIN;

        if (m_emitterManager.m_maxFireRate >= 0)
            m_emitterManager.m_maxFireRate -= M_FIRE_RATE_DECREASE_MAX;
    }
}