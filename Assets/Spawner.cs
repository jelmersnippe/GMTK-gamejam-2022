using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyRuntimeSet enemiesToSpawn;

    public void Spawn()
    {
        ClearActiveEnemies();
        foreach (Enemy enemy in enemiesToSpawn.items)
        {
            // TODO: Add proper spawn randomization
            Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity, transform);
        }
    }

    public void ClearActiveEnemies()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
