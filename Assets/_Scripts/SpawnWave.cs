//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnWave: MonoBehaviour {

    [SerializeField] Transform[] enemies;
    [SerializeField] Transform[] spawnPoints;

    //public int enemyCount = 0;

    [Space(15)]
    public List<GameObject> enemiesAlive;

    [Header("Udemy Spawning")]
    [SerializeField] Transform UdemyPrefab;
    [SerializeField] float udemySpawnTime;
    [SerializeField] float currentTime = 0;

    
    private void Start() {
        Init();
        enemiesAlive = new List<GameObject>();
        SpawnNewEnemies();
    }

    private void Update() {
        currentTime += Time.deltaTime;
    }
    private void Init() {
        udemySpawnTime = Random.Range(5, 10);
    }

    public  void EnemySpawned(GameObject enemy) {
        //enemyCount++;
        enemiesAlive.Add(enemy);
        //Debug.Log("Enemy Spawned -  Count is " + enemyCount);
    }

    public  void EnemyKilled(GameObject enemy) {
      //  enemyCount--;
        enemiesAlive.Remove(enemy);
    }

    public void SpawnNewEnemies() {
      //  Debug.Log("Spawning new enemies " + enemyCount);
       // enemyCount = 0;
        //Check for boss wave
        if (currentTime > udemySpawnTime) {
            GetComponent<AudioSource>().Play();
            Invoke("SpawnUdemyBoss", .5f);
            return;
        }
        else {
            foreach (Transform point in spawnPoints) {
                int rnd = Random.Range(0, spawnPoints.Length);
                int rndEnemy = Random.Range(0, enemies.Length);

                //Instantiate(enemies[rndEnemy], spawnPoints[rnd].position, Quaternion.identity);
                Transform go = Instantiate(enemies[rndEnemy], point.position, Quaternion.identity); // THIs creates one on each without overlap

                enemiesAlive.Add(go.gameObject);
                //   enemyCount++;
            }
        }
    }

    void SpawnUdemyBoss() {
       // enemyCount = 1;
        currentTime = 0;
        Transform go = Instantiate(UdemyPrefab, Vector3.zero, Quaternion.identity); // THIs creates one on each without overlap
        enemiesAlive.Add(go.gameObject);
    }
    public void ClearBossWave() {
        currentTime = 0;
    }
}