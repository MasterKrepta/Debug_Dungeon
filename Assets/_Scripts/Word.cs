using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{

    private string _wordName;
    private int index;
    private bool wordDone;

    public Word(string word) {
        WordName = word;
        index = 0;
        WordDone = false;
    }

    public string WordName {
        get {
            return _wordName;
        }

        set {
            _wordName = value;
        }
    }

    public bool WordDone {
        get {
            return wordDone;
        }

        set {
            wordDone = value;
        }
    }

    public char GetNextLetter() {
        if (index >= WordName.Length) {
            Debug.Log("Done!!!!!!");
            WordDone = true;
            
        }
        return WordName[index];
    }
    public void EnterLetter() {
        index++;
        if (index >= WordName.Length) {
            //Debug.Log("Done!!!!!!");
            WordDone = true;
        }
        //remove visual
    }
}
