using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWord : MonoBehaviour {

    public Transform parent;

    public float fallSpeed = 1f;

    TMP_Text text;

    private void Awake() {
        text = GetComponent<TMP_Text>();
        parent = this.transform.parent.parent;
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
        UpdateWordCount();
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
    }

    //This SHOULD  update the canvas count on the enemy, so we can let it know when all the words
    //have been cleared so we can delete the enemy
    public void UpdateWordCount() {
        parent.GetComponent<SpawnTimer>().DecreaseWordCount();
    }

    //private void Update() {
    //    transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    //}
}

