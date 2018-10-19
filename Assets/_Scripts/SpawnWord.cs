using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnWord : MonoBehaviour {

    public GameObject wordPrefab;
    
    public DisplayWord Spawn(Transform canvas) {
    
        GameObject wordObj = Instantiate(wordPrefab, canvas.position, Quaternion.identity, canvas);
        DisplayWord displayWord = wordObj.GetComponent<DisplayWord>();
        return displayWord;
    }
}

