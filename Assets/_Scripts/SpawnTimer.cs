using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

    public float spawnDelay = 1.5f;
    float nextTime = 1f;

    InputParser inputParser;

    private void Start() {
        inputParser = GetComponent<InputParser>();
    }
    private void Update() {
        if (Time.time >= nextTime) {
            inputParser.AddWord();
            nextTime = Time.time + spawnDelay;
            spawnDelay *= .99f;
        }
    }

    private void NextWave() {
        WordGenerator.GetRandomWord();
    }

}
