using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyRuntimeSet enemiesToSpawn;
    public float minXOffset = 7.5f;
    public float maxXOffset = 15f;
    public float minYOffset = 7.5f;
    public float maxYOffset = 15f;

    public void Spawn()
    {
        foreach (Enemy enemy in enemiesToSpawn.items)
        {

            // TODO: Add proper spawn randomization
            Instantiate(enemy, GetSpawnPosition(), Quaternion.identity, transform);
        }
    }

    public void ClearActiveEnemies()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        float x = Random.Range(minXOffset, maxXOffset);
        x = Random.Range(0f, 1f) > 0.5f ? x : -x;
        float y = Random.Range(minYOffset, maxYOffset);
        y = Random.Range(0f, 1f) > 0.5f ? y : -y;

        return new Vector3(x, y);
    }
}
