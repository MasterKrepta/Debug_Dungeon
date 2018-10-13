using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWord : MonoBehaviour {

    [SerializeField] Text txtToMatch;
    [SerializeField] Text txtEntered;

    public void UpdateDisplayText(Word wordToMatch) {
        txtToMatch.text = wordToMatch.WordName;
    }
    public void UpdateDisplayText(Phrase phraseToMatch) {
        txtToMatch.text = phraseToMatch.PhraseName;
    }

    public void UpdateInput(string input) {
        txtEntered.text = input;
    }

    public void ClearInput() {
        txtEntered.text = "";
    }

}
