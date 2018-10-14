using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase  {

    private string phrase;
    private int index;

    DisplayWord display;

    public Phrase(string phrase, DisplayWord display) {
        this.phrase = phrase;
        index = 0;

        this.display = display;
        display.PlacePhrase(phrase);
    }

    public char GetNextLetter() {
        return phrase[index];
    }
    public void EnterLetter() {
        index++;
        PhraseComplete();
    }

    public bool PhraseComplete() {
        bool phraseDone = (index >= phrase.Length);
        if (phraseDone)
            display.RemovePhrase();

        return phraseDone;

    }
}
