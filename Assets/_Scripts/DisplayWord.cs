using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWord : MonoBehaviour {

    [SerializeField] Text txtToMatch;
    [SerializeField] Text txtEntered;

    public void UpdateDisplayText(Word wordToMatch) {
        txtToMatch.text = wordToMatch.WordName;
        txtToMatch.color = Color.red;
    }

    public void DisplayTextAtLocation(Text txt, Word word, Vector3 position) {
        txt.text = word.WordName;
        txt.color = Color.red;
        

    }

    public void RemoveLetter() {
        txtToMatch.text = txtToMatch.text.Remove(0, 1);
        txtToMatch.color = Color.green;
    }

    #region ChangeColor
    //public void UpdateProgress(string str) {
    //    StringBuilder strBuild = new StringBuilder(txtToMatch.text);
    //    int length = str.Length;

    //    for (int i = 0; i < length; i++) {
    //        strBuild.Replace(str.ToString(), "<color=#FF0000>" + str[i] + "</color>");
    //        txtToMatch.text = strBuild.ToString();
    //    }
    //}
    #endregion


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
