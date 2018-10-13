using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class WordGenerator {

    public static List<Word> WordList = new List<Word>();
    public static List<Phrase> PhraseList = new List<Phrase>();

    public static Word GetRandomWord() {
        
        //Debug.Log(WordList.Count);
        int index = Random.Range(0, WordList.Count);
        return WordList[index];
   }
    public static Phrase GetRandomPhrase() {
        //Debug.Log(PhraseList.Count);
        int index = Random.Range(0, PhraseList.Count);
        return PhraseList[index];
    }

    public static void PopulateWordList() {
        string line;
        StreamReader file = new StreamReader("Assets/Data/Random Words.txt");

        while ((line = file.ReadLine()) != null) {
            Word newWord = new Word(line);
            WordList.Add(newWord);
        }
    }

    public static void PopulatePhraseList() {
        string line;
        StreamReader file = new StreamReader("Assets/Data/Random Phrases.txt");

        while ((line = file.ReadLine()) != null) {
            //TODO this will not work properly for display reasons, come up with something better
            line = line.Replace(" ", ""); // RemoveSpaces

            Phrase newPhrase = new Phrase(line);
            PhraseList.Add(newPhrase);
        }
    }



}