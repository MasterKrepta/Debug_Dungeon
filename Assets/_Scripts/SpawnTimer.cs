using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimer : MonoBehaviour {

    SpawnWave spawnWave;
    bool isBoss;
    //TODO this should be on another script
    int wordCount= 0;

    public float spawnDelay = 1.5f;
    float nextTime = 1f;

    InputParser inputParser;
    public Transform[] myCanvases;

    private void Awake() {
        inputParser = FindObjectOfType<InputParser>();
        spawnWave = FindObjectOfType<SpawnWave>();
        ConfigCanvas();
        Invoke("SpawnNewWords", 2);
    }

    private void ConfigCanvas() {
        //TODO maybe preset all the canvases by default to prevent Errors?
    }
   
    private void SpawnNewWords() {
        foreach (Transform c in myCanvases) {
            if (c.childCount == 0) {
                inputParser.AddWord(c);
                wordCount++;
            }
        }
    }

    public void DecreaseWordCount() {
        wordCount--;
        //Check for boss
        isBoss = IsBoss();
        if (isBoss == true) {
            UdemyBoss boss = this.GetComponent<UdemyBoss>();
            //? do we need this 
           // spawnWave.enemyCount = 1;
            boss.Damage(1);

            if (boss.CurrentHealth > 0) {
                SpawnNewWords();
                return;
            }
            else {
                Destroy(gameObject);
                spawnWave.EnemyKilled(this.gameObject);
            //     if (spawnWave.enemyCount <= 0) {
                if (spawnWave.enemiesAlive.Count == 0) {
                    spawnWave.SpawnNewEnemies();
                }
            }

        }
        //If Not Boss
        if (wordCount <= 0) {
            Destroy(gameObject);
            spawnWave.EnemyKilled(this.gameObject);
            // if (spawnWave.enemyCount <= 0) {
            if (spawnWave.enemiesAlive.Count == 0) {
                spawnWave.SpawnNewEnemies();
            }
        }

        //TODO update score
    }

    bool IsBoss() {
        if (this.GetComponent<UdemyBoss>() != null) {
            return true;
        }
        else {
            return false;
        }
    }
}
