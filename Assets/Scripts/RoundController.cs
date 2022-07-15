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
        if (currentRound.value == 1)
        {
            // TODO: Don't keep this reference
            playerDamageable = Instantiate(playerPrefab).GetComponent<Damageable>();
            OnPlayerSpawn.Raise();
        }
    }
}
