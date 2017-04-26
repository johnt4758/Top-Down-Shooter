using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemyReaminingToSPawn;
    int enemyReamingAlive;
    float nextSpawnTime;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (enemyReaminingToSPawn > 0 && Time.time > nextSpawnTime)
        {
            enemyReaminingToSPawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawn;

            Enemy spawnEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnEnemy.OnDeath += OnEnemyDeath;
        }

    }

    void OnEnemyDeath()
    {
        enemyReamingAlive--;
        if (enemyReamingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemyReaminingToSPawn = currentWave.enemyCount;
            enemyReamingAlive = enemyReaminingToSPawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public int timeBetweenSpawn;
    }
}
