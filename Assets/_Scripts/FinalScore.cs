using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {

    [SerializeField] TMP_Text errors;
    [SerializeField] TMP_Text entered;
    [SerializeField] TMP_Text cleared;
    [SerializeField] TMP_Text percentages;

    // Use this for initialization
    void Start () {
        errors.text = "Errors Made: " + ScoreManager.errors;
        entered.text = "Entered Letters: " + ScoreManager.charsEntered;
        cleared.text = "Words Cleared: " + ScoreManager.wordsCleared;
        percentages.text = "Accuracy: " + ScoreManager.percentage;
    }
	
    public void ReStart() {
        SceneManager.LoadScene(1);
    }

    public void EndGame() {
        Application.Quit();
    }
}
