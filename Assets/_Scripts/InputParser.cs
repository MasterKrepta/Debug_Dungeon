using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour
{

    [SerializeField] Word wordToMatch;
    [SerializeField] Phrase phraseToMatch;
    [SerializeField] DisplayWord displayWord;
    string enteredString = "";
    // Use this for initialization
    void Start() {
        WordGenerator.PopulateWordList();
        WordGenerator.PopulatePhraseList();
        GetNewWord();
        //TODO phrases dont work properly, needs debugging
        //GetNewPhrase();
    }

    private void GetNewWord() {
        displayWord.ClearInput();
        enteredString = "";

        wordToMatch = WordGenerator.GetRandomWord();
        displayWord.UpdateDisplayText(wordToMatch);
    }
    private void GetNewPhrase() {
        displayWord.ClearInput();
        enteredString = "";

        phraseToMatch = WordGenerator.GetRandomPhrase();
        displayWord.UpdateDisplayText(phraseToMatch);
    }

    private void UpdateEnteredString(string str, bool isNewWord) {
        if (!isNewWord) {
            displayWord.RemoveLetter();
        }
        
        displayWord.UpdateInput(str);
    }

    void Update() {
        foreach (char letter in Input.inputString) {
            CheckEnteredWord(wordToMatch, letter);
            //CheckEnteredPhrase(phraseToMatch, letter);
        }
    }

    private void CheckEnteredWord(Word wordToMatch, char letter) {

        if (wordToMatch.WordDone) {
            GetNewWord();
            UpdateEnteredString("", true);
            return;
        }
        if (wordToMatch.GetNextLetter() == letter && wordToMatch.WordDone == false && wordToMatch.GetNextLetter() != null) {
            //We matched;
            //TODO update graphics to make the enemy flash
            enteredString += letter;
            wordToMatch.EnterLetter();
            UpdateEnteredString(enteredString, false);

            //Debug.Log("Good: next letter is : " + wordToMatch.GetNextLetter());
        }
    }
    private void CheckEnteredPhrase(Phrase phraseToMatch, char letter) {
        if (phraseToMatch.PhraseDone) {
            GetNewPhrase();
            UpdateEnteredString("", true);
            return;
        }
        if (phraseToMatch.GetNextLetter() == letter && phraseToMatch.PhraseDone == false && phraseToMatch.GetNextLetter() != null) {
            //We matched;
            enteredString += letter;
            phraseToMatch.EnterLetter();
            UpdateEnteredString(enteredString, false);

            //Debug.Log("Good: next letter is : " + wordToMatch.GetNextLetter());
        }
    }
}
