using System.Collections;
using Enemies.Emitter;
using Enemies.Projectile;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player.Player m_player;
    [SerializeField] private EmitterManager m_emitterManager;

    [SerializeField] private GameObject m_inputBlockingPanel;

    private const float M_GAME_START_DELAY = 1.5f;
    private const float M_GAME_END_DELAY = 2.5f;

    private Coroutine m_emitterShootingRoutine;

    private void Start()
    {
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
        while (m_player.isAlive)
        {
            yield return null;
        }
    }

    private IEnumerator GameEnding()
    {
        StopCoroutine(m_emitterShootingRoutine);
        m_inputBlockingPanel.SetActive(true);
        foreach (Projectile projectile in m_emitterManager.m_ProjectilePool)
            projectile.gameObject.SetActive(false);
        m_emitterManager.m_rotationSpeed = 0;
        yield return new WaitForSeconds(M_GAME_END_DELAY);
        SceneManager.LoadScene(0);
    }
}