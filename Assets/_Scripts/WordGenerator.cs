using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class WordGenerator {

    public static List<string> WordList = new List<string>();
    public static List<string> PhraseList = new List<string>();
   
    public static string GetRandomWord() {
        int index = Random.Range(0, WordList.Count);
        
        return WordList[index];
   }


    public static void PopulateWordList() {
        string line;
        StreamReader file = new StreamReader("Assets/Data/Random Phrases.txt");

        while ((line = file.ReadLine()) != null) {
            string newWord = line;
            WordList.Add(newWord.ToLower());
        }
    }


}
