using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour{

    public  List<Word> words;
    public List<Phrase> phrases;

    public SpawnWord spawner;
    public SpawnWave spawnWave;

    private  bool hasActiveWord;
    public Word activeWord;

    //!this was for testing
    //public List<string> possiblewords;
    
    // Use this for initialization
    void Start() {
        //!this was for testing
        //possiblewords = WordGenerator.WordList;
        spawner = GetComponent<SpawnWord>();
        spawnWave = GetComponent<SpawnWave>();
        WordGenerator.PopulateWordList();
        WordGenerator.PopulatePhraseList();
        
    }

    public void AddWord(Transform canvas) {
        Word newWord = new Word(WordGenerator.GetRandomWord(), spawner.Spawn(canvas));
        words.Add(newWord);
    }

    
    //GET THE INPUT HERE 
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
//            spawnWave.SpawnNewEnemies();
        }
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
            else {
                //We made an error
                //TODO display something visual to indicate the mistake
                ScoreManager.UpdateErrors();
            }
        }
        else {
            foreach (Word word in words) {
                
                if (word.GetNextLetter() == letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.EnterLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordComplete()) {
            hasActiveWord = false;
            activeWord = null;
            words.Remove(activeWord);
        }
    }

}