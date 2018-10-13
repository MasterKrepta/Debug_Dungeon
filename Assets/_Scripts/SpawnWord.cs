using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnWord : MonoBehaviour {

    [SerializeField] DisplayWord displayWord;
    [SerializeField]TMP_Text[] textDisplay;

	// Use this for initialization
	void Start () {

        foreach (TMP_Text text in textDisplay) {
            //text.enabled = false;
        }	
	}
	
    public void SpawnWords() {
        foreach ( TMP_Text text in textDisplay) {
            text.enabled = true;
            displayWord.UpdateDisplayText(wordToMatch);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            SpawnWords();
        }
    }
}

