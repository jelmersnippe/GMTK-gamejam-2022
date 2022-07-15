using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyRuntimeSet enemiesToSpawn;

    public void Spawn()
    {
        foreach (Enemy enemy in enemiesToSpawn.items)
        {
            // TODO: Add proper spawn randomization
            Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity, transform);
        }
    }
}
