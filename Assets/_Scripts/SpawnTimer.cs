using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour {

    public float spawnDelay = 1.5f;
    float nextTime = 1f;

    private void Update() {
        if (Time.time >= nextTime) {
            WordGenerator.GetRandomWord();
            nextTime = Time.time + spawnDelay;
            //spawnDelay *= .99f;
        }
    }

    private void NextWave() {
        WordGenerator.GetRandomWord();
    }

}
