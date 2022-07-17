using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameEvent OnDeath;
    public EnemyRuntimeSet activeEnemies;
    public Damageable damageable;
    public IntReference currentRound;
    public int healthIncreasePerRound = 4;

    private void OnEnable()
    {
        activeEnemies.Add(this);
    }

    private void Start()
    {
        damageable.UpdateMaxHealth(healthIncreasePerRound * currentRound);
    }

    private void OnDisable()
    {
        activeEnemies.Remove(this);
        OnDeath.Raise();
    }
}
