using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    public static int wordsCleared = 0;
    public static int charsEntered = 0;
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
        //calculate errors 
        float percentRight = charsEntered - errors;

        percentage = percentRight/ charsEntered; //Correct / Total

        //Format as a percentage
        percentage *= 100; //move decimal

        //Debug.Log("You made: " + errors + " Errors");
        //Debug.Log("You entered: " + charsEntered + " Characters");
        //Debug.Log("You Cleared: " + wordsCleared + " Words");
        //Debug.Log("Percentage: " + percentage);
    }

}
