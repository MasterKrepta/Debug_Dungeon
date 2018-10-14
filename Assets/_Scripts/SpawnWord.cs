using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnWord : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;

    public DisplayWord Spawn() {
        //TODO spawn one word on each enemy spawn point in scene
        //Use a for each loop to get all active spawners then instantiate one at each position
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f),7f);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        DisplayWord displayWord = wordObj.GetComponent<DisplayWord>();
        return displayWord;
    }
        
	
}

