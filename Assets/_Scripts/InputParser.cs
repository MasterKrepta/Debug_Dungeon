using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputParser : MonoBehaviour{

    public  List<Word> words;
    

    public SpawnWord spawner;
    public SpawnWave spawnWave;

    private  bool hasActiveWord;
    public Word activeWord;

    //!this was for testing
    //public List<string> possiblewords;
    
    // Use this for initialization
    void Awake() {
        //!this was for testing
        //possiblewords = WordGenerator.WordList;
        spawner = GetComponent<SpawnWord>();
        spawnWave = GetComponent<SpawnWave>();
        WordGenerator.PopulateWordList();
      
    }

    public void AddWord(Transform canvas) {
        Word newWord = new Word(WordGenerator.GetRandomWord(), spawner.Spawn(canvas));
        words.Add(newWord);
    }

    //GET THE INPUT HERE 
    void Update() {

        foreach (char letter in Input.inputString) {
            InputLetter(letter);
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
            //? Remove the active word from the list - reset it as null not required
            words.Remove(activeWord);
        }
    }

}