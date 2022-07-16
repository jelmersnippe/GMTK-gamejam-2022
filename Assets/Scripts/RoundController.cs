using UnityEngine;

public class RoundController : MonoBehaviour
{
    public PlayerInput playerPrefab;


    // TODO: Remove this link
    public Damageable playerDamageable;
    public IntVariable currentRound;
    public EnemyRuntimeSet activeEnemies;
    public IntReference currentPlayerHealth;
    public GameEvent OnRoundWin;
    public GameEvent OnRoundLose;
    public GameEvent OnPlayerSpawn;

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        Time.timeScale = 0;
    }

    public void ValidateWinCondition()
    {
        if (activeEnemies.items.Count <= 0)
        {
            TriggerWinCondition();
        }
    }

    public void ValidateLoseCondition()
    {
        if (currentPlayerHealth.Value <= 0)
        {
            TriggerLoseCondition();
        }
    }

    private void TriggerLoseCondition()
    {
        Debug.LogWarning("Player died!");
        currentRound.SetValue(1);
        OnRoundLose.Raise();
        gameObject.SetActive(false);
    }

    private void TriggerWinCondition()
    {
        Debug.LogWarning("No active enemies!");
        currentRound.ApplyChange(+1);
        OnRoundWin.Raise();
        gameObject.SetActive(false);
    }

    public void SpawnPlayer()
    {
        // TODO: Don't keep this reference
        if (playerDamageable == null)
        {
            playerDamageable = Instantiate(playerPrefab).GetComponent<Damageable>();
        }

        playerDamageable.transform.position = Vector3.zero;
        OnPlayerSpawn.Raise();
    }

    public void RemoveActiveProjectiles()
    {
        Projectile[] activeProjectiles = FindObjectsOfType<Projectile>();

        foreach (Projectile projectile in activeProjectiles)
        {
            Destroy(projectile.gameObject);
        }
    }
}
