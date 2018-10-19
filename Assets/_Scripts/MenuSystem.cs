using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

    public float startDelay = 3f;

    public void StartGame() {
        StartCoroutine(DelayStart());
    }
    
    IEnumerator DelayStart() {
        yield return new WaitForSeconds(startDelay);
        SceneManager.LoadScene(1);
    }
}
