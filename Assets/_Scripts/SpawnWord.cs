using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnWord : MonoBehaviour {

    public GameObject wordPrefab;

    public DisplayWord Spawn() {
        GameObject wordObj = Instantiate(wordPrefab);

        DisplayWord displayWord= wordObj.GetComponent<DisplayWord>();
        return displayWord;
    }
        
	
}

