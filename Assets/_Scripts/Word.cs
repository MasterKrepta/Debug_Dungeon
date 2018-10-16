using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int index;
    

    DisplayWord display;

    public Word(string word, DisplayWord display) {
        this.word = word;
        index = 0;
        
        this.display = display;
        display.PlaceWord(word);
    }
    
    public char GetNextLetter() {
        char next = word[index];
        if (next == ' ' || next == '-' || next == '\'' || next == ',') {
            index++; // if its a space or dash
            display.RemoveLetter();
        }
        return word[index];
    }
    public void EnterLetter() {
        index++;
        display.RemoveLetter();
        
    }

    public bool WordComplete() {
        bool wordDone = (index >= word.Length);
        if (wordDone) {
            ScoreManager.UpdateClearedWords(this);
            display.RemoveWord();
        }
            

        return wordDone;
                
    }
}
