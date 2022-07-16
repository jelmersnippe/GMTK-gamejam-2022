using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameEvent OnDeath;
    public EnemyRuntimeSet activeEnemies;

    private void OnEnable()
    {
        activeEnemies.Add(this);
    }

    private void OnDisable()
    {
        activeEnemies.Remove(this);
        OnDeath.Raise();
    }
}
