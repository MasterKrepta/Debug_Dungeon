using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour{


    public  List<Word> words;
    public List<Phrase> phrases;

    public SpawnWord spawner;

    private  bool hasActiveWord;
    private Word activeWord;
    
    
    // Use this for initialization
    void Start() {
        spawner = GetComponent<SpawnWord>();
        WordGenerator.PopulateWordList();
        WordGenerator.PopulatePhraseList();
    

        //TODO phrases dont work properly, needs debugging
        //GetNewPhrase();
    }

    public void AddWord() {
        Word newWord = new Word(WordGenerator.GetRandomWord(), spawner.Spawn());
        Debug.Log(newWord.word);
        words.Add(newWord);
        
    }

    private void GetNewPhrase() {
        Phrase newPhrase = new Phrase(WordGenerator.GetRandomPhrase(), spawner.Spawn());
        phrases.Add(newPhrase);
    }

    

    //GET THE INPUT HERE 
    void Update() {
        foreach (char letter in Input.inputString) {
            InputLetter(letter);
            //CheckEnteredPhrase(phraseToMatch, letter);
        }
    }

    public void InputLetter(char letter) {

        if (hasActiveWord) {
            if (activeWord.GetNextLetter() == letter) {
                //We matched;
                activeWord.EnterLetter();
                //TODO update graphics to make the enemy flash
            }
        }
        else {
            foreach (Word word in words) {
                if (word.GetNextLetter() == letter) {
                    activeWord = word;
                    Debug.Log(activeWord.word + " is the active word");
                    hasActiveWord = true;
                    word.EnterLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordComplete()) {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }

    private void CheckEnteredPhrase(Phrase phraseToMatch, char letter) {
        
    }


}