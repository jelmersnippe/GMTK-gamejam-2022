using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemySpawnRuntimeDictionary enemiesToSpawn;

    public void Spawn()
    {
        ClearActiveEnemies();
        foreach (KeyValuePair<Enemy, int> enemySpawn in enemiesToSpawn.items)
        {
            for (int i = 0; i < enemySpawn.Value; i++)
            {
                // TODO: Add proper spawn randomization
                Instantiate(enemySpawn.Key, new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity, transform);
            }
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
