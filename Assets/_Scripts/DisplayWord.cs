using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWord : MonoBehaviour {

    public Transform parent;
    AudioSource audio;

    public float fallSpeed = 1f;

    TMP_Text text;

    private void Awake() {
        text = GetComponent<TMP_Text>();
        audio = GetComponent<AudioSource>();
        parent = this.transform.parent.parent;
    }


    public void PlaceWord(string word) {
        text.text = word;
        text.color = Color.red;
    }



    public void RemoveWord() {
        //TODO play some special graphic
        audio.Play();
        Invoke("DestroyAfterAudio", 1);
        
        UpdateWordCount();
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
    }

    
    public void UpdateWordCount() {
        parent.GetComponent<SpawnTimer>().DecreaseWordCount();
    }

    private void DestroyAfterAudio() {
        Destroy(gameObject);
    }
}

