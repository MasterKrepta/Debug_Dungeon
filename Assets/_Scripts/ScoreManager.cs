using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    public static int wordsCleared = 0;
    private static int charsEntered = 0;
    public static int errors = 0;
    public static float percentage = 100;

    public static void UpdateClearedWords(Word word) {
        string wordLength = word.word;
        for (int i = 0; i < wordLength.Length; i++) {
            charsEntered++;
        }
        wordsCleared++;
    }

    public static void UpdateErrors() {
        errors++;
    }

    public static void GetPercentages() {
        //TODO calculate errors 
        percentage = (charsEntered - errors )/ charsEntered; //Correct / Total
        Debug.Log("You made: " + errors + " Errors");
        Debug.Log("You Cleared: " + wordsCleared + " Words");
        Debug.Log("Percentage: " + percentage);
    }

}
