using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimer : MonoBehaviour {

    SpawnWave spawnWave;
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
        Invoke("NextWave", 2);
    }

    private void ConfigCanvas() {
        //TODO maybe preset all the canvases by default to prevent Errors?
    }
   
    private void NextWave() {
        foreach (Transform c in myCanvases) {
            inputParser.AddWord(c);
            wordCount++;
        }
    }

    public void DecreaseWordCount() {
        wordCount--;
        if (wordCount <= 0) {
            Destroy(gameObject);
            spawnWave.EnemyKilled();

            if(spawnWave.enemyCount <= 0) {
                spawnWave.SpawnNewEnemies();
            }

            //TODO update score
        }
    }
}
