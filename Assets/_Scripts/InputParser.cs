using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour{
    [SerializeField] Word wordToMatch;
    [SerializeField] Phrase phraseToMatch;
    [SerializeField] DisplayWord displayWord;
    public  List<Word> words;

    private  bool hasActiveWord;
    private Word activeWord;
    
    string enteredString = "";
    // Use this for initialization
    void Start() {
        WordGenerator.PopulateWordList();
        WordGenerator.PopulatePhraseList();
        GetNewWord();
        GetNewWord();
        GetNewWord();
        //TODO phrases dont work properly, needs debugging
        //GetNewPhrase();
    }

    private void GetNewWord() {
        displayWord.ClearInput();
        enteredString = "";

        wordToMatch = WordGenerator.GetRandomWord();
        words.Add(wordToMatch);

        //TODO this may need to be moved
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

        if (hasActiveWord) {
            if (wordToMatch.GetNextLetter() == letter && wordToMatch.WordDone == false && wordToMatch.GetNextLetter() != null) {
                //We matched;
                activeWord.EnterLetter();
                //TODO update graphics to make the enemy flash
                enteredString += letter;
                wordToMatch.EnterLetter();
                UpdateEnteredString(enteredString, false);

                //Debug.Log("Good: next letter is : " + wordToMatch.GetNextLetter());
            }
        }
        else {
            foreach (Word word in words) {
                if (word.GetNextLetter() == letter) {
                    activeWord = word;
                    Debug.Log( activeWord + " is the active word");

                    wordToMatch = word;
                    hasActiveWord = true;
                    word.EnterLetter();
                    break;
                }
            }
        }

        if (wordToMatch.WordDone) {
            
            Debug.Log("word is done");
            hasActiveWord = false;
            words.Remove(wordToMatch);
            GetNewWord();
            UpdateEnteredString("", true);
            return;
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