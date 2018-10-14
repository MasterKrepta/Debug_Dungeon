using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWord : MonoBehaviour {

    public Text text;
    public float fallSpeed = 1f;

    //TMP_Text text;

    private void Awake() {
        //text = GetComponent<TMP_Text>();
        text = GetComponent<Text>();
    }
    internal void PlacePhrase(string phrase) {
        throw new NotImplementedException();
    }

    public void PlaceWord(string word) {
        text.text = word;
        text.color = Color.red;
    }

    public void RemovePhrase() {
        throw new NotImplementedException();
    }

    public void RemoveWord() {
        //TODO play some special graphic
        Destroy(gameObject);
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
    }

    private void Update() {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}

