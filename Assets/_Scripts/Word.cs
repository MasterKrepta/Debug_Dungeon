using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int index;
    public string formated;

    DisplayWord display;

    public Word(string word, DisplayWord display) {
        this.word = word;
        index = 0;
        formated = FormatText(word);
        this.display = display;
        display.PlaceWord(word);
    }

    private string FormatText(string word) {
        string formated = word;
        formated = formated.Replace(" ", ""); // RemoveSpaces
        formated = formated.Replace("-", ""); // Remove Dashes
        return formated;
    }

    public char GetNextLetter() {
        
        return word[index];
    }
    public void EnterLetter() {
        index++;
        display.RemoveLetter();
    }

    public bool WordComplete() {
        bool wordDone = (index >= word.Length);
        if (wordDone)
            display.RemoveWord();

        return wordDone;
                
    }
}
