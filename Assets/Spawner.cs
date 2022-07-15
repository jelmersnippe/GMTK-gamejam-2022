using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyDice enemyDice;
    public float spawnDelay = 2f;
    public float spawnInterval = 5f;
    private float remainingTimeBetweenSpawns;

    private void Update()
    {
        if (spawnDelay > 0)
        {
            spawnDelay -= Time.deltaTime;
            return;
        }

        remainingTimeBetweenSpawns -= Time.deltaTime;

        if (remainingTimeBetweenSpawns <= 0)
        {
            Spawn();
            remainingTimeBetweenSpawns = spawnInterval;
        }
    }

    public void Spawn()
    {
        DiceOption<Enemy> enemyRoll = enemyDice.Roll();
        Instantiate(enemyRoll.value, transform);
    }
}
