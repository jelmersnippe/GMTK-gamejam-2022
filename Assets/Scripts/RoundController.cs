using UnityEngine;

public class RoundController : MonoBehaviour
{
    public EnemyRuntimeSet activeEnemies;
    public IntReference playerHealth;
    public GameEvent OnRoundWin;

    private void Update()
    {
        // TODO: Should listen to an enemy death event instead for performance
        if (activeEnemies.items.Count <= 0)
        {
            Debug.LogWarning("No active enemies!");
            OnRoundWin.Raise();
        }
        if (playerHealth.value <= 0)
        {
            Debug.LogWarning("Player died!");
        }
    }
}
