using UnityEngine;

public class RoundController : MonoBehaviour
{
    public PlayerInput playerPrefab;

    public IntReference currentRound;
    public EnemyRuntimeSet activeEnemies;
    // TODO: Change back to Reference once we've fixed it in the player/enemy damageable
    // public IntReference playerHealth;
    public Damageable playerDamageable;
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

    private void Update()
    {
        // TODO: Should listen to an enemy death event instead for performance
        if (activeEnemies.items.Count <= 0)
        {
            Debug.LogWarning("No active enemies!");
            currentRound.value++;
            OnRoundWin.Raise();
            enabled = false;
        }
        if (playerDamageable.currentHealth <= 0)
        {
            Debug.LogWarning("Player died!");
            currentRound.value = 1;
            OnRoundLose.Raise();
            enabled = false;
        }
    }

    public void SpawnPlayer()
    {
        // TODO: Don't keep this reference
        if (playerDamageable == null)
        {
            playerDamageable = Instantiate(playerPrefab).GetComponent<Damageable>();
            OnPlayerSpawn.Raise();
        }

        playerDamageable.transform.position = Vector3.zero;
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
