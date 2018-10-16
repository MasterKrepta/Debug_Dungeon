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

    public List<string> possiblewords;
    
    // Use this for initialization
    void Start() {
        possiblewords = WordGenerator.WordList;
        spawner = GetComponent<SpawnWord>();
        spawnWave = GetComponent<SpawnWave>();
        WordGenerator.PopulateWordList();
        WordGenerator.PopulatePhraseList();
        //TODO phrases dont work properly, needs debugging
        //GetNewPhrase();
    }

    public void AddWord(Transform canvas) {
        Word newWord = new Word(WordGenerator.GetRandomWord(), spawner.Spawn(canvas));
        words.Add(newWord);
    }

    private void GetNewPhrase(Transform canvas) {
        Phrase newPhrase = new Phrase(WordGenerator.GetRandomPhrase(), spawner.Spawn(canvas));
        phrases.Add(newPhrase);
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
            words.Remove(activeWord);
        }
    }

    private void CheckEnteredPhrase(Phrase phraseToMatch, char letter) {
        
    }
}