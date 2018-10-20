//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpawnWave: MonoBehaviour {

    [SerializeField] Transform[] enemies;
    [SerializeField] Transform[] spawnPoints;

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
        udemySpawnTime = Random.Range(45, 90);
    }

    public  void EnemySpawned(GameObject enemy) {
        enemiesAlive.Add(enemy);
    }

    public  void EnemyKilled(GameObject enemy) {
        enemiesAlive.Remove(enemy);
    }

    public void SpawnNewEnemies() {
      
        //Check for boss wave
        if (currentTime > udemySpawnTime) {
            GetComponent<AudioSource>().Play();
            Invoke("SpawnUdemyBoss", .5f);
            return;
        }
        else {
            foreach (Transform point in spawnPoints) {
                int rndEnemy = Random.Range(0, enemies.Length);
                
                Transform go = Instantiate(enemies[rndEnemy], point.position, Quaternion.identity); // THIs creates one on each without overlap
                enemiesAlive.Add(go.gameObject);
            }
        }
    }

    void SpawnUdemyBoss() {
       
        currentTime = 0;
        Transform go = Instantiate(UdemyPrefab, Vector3.zero, Quaternion.identity); // THIs creates one on each without overlap
        enemiesAlive.Add(go.gameObject);
    }
    public void ClearBossWave(PlayerManager player) {
        //Clear any active words to prevent errors
        player.GetComponent<InputParser>().words.Clear();
        player.GetComponent<InputParser>().activeWord = null;
        currentTime = 0;
    }
}