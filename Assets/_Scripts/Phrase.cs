using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase  {

    private string _phraseName;
    private int index;
    private bool phraseDone;

    public Phrase(string phrase) {
        PhraseName = phrase;
        index = 0;
        PhraseDone = false;
    }

    public string PhraseName {
        get {
            return _phraseName;
        }

        set {
            _phraseName = value;
        }
    }

    public bool PhraseDone {
        get {
            return phraseDone;
        }

        set {
            phraseDone = value;
        }
    }

    public char GetNextLetter() {
        if (index >= PhraseName.Length) {
            Debug.Log("Done!!!!!!");
            PhraseDone = true;

        }
        return PhraseName[index];
    }
    public void EnterLetter() {
        index++;
        if (index >= PhraseName.Length) {
            Debug.Log("Done!!!!!!");
            PhraseDone = true;
        }
        //remove visual
    }
}
