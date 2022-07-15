using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyRuntimeSet activeEnemies;
    private void OnEnable()
    {
        activeEnemies.Add(this);
    }

    private void OnDisable()
    {
        activeEnemies.Remove(this);
    }
}
