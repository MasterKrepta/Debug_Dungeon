using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnWave: MonoBehaviour {

    [SerializeField] Transform[] enemies;
    [SerializeField] Transform[] spawnPoints;

    public  int enemyCount = 0;

    public  void EnemySpawned() {
        enemyCount++;
        
    }

    public  void EnemyKilled() {
        enemyCount--;
    }

    public void SpawnNewEnemies() {
        enemyCount = 0;
        foreach (Transform point in spawnPoints) {
            int rnd = Random.Range(0, spawnPoints.Length);
            int rndEnemy = Random.Range(0, enemies.Length);

            //Instantiate(enemies[rndEnemy], spawnPoints[rnd].position, Quaternion.identity);
            Instantiate(enemies[rndEnemy], point.position, Quaternion.identity); // THIs creates one on each without overlap
            enemyCount++;
        }
    }
}
