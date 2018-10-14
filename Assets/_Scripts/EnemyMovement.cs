using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Vector3 startingPos;
    enum direction {LEFT, RIGHT, DOWN};
    direction dir = direction.DOWN;
    [SerializeField] float speed = 2;

    [Header ("Stopping Vars")]
    [Space (5)]
    [SerializeField]int stoppingRight = 3;
    [SerializeField]int stoppingDown = -2;

    // Use this for initialization
    void Start () {
        startingPos = transform.position;
        DetermineDirection();
    }

    private void DetermineDirection() {
        startingPos.x = Mathf.Floor(startingPos.x);
        startingPos.y = Mathf.Floor(startingPos.y);
        if (startingPos.x < 0) {
            dir = direction.RIGHT;
            startingPos.y = 0;
        }
        else if (startingPos.x > 0) {
            dir =direction.LEFT;
            startingPos.y = 0;
        }
        else if (startingPos.y > 0) {
            dir = direction.DOWN;
            startingPos.x = 0;
        }
        else {
            Debug.Log("DEFAULTNG DOWN");
            dir = direction.DOWN;
        }
    }

    // Update is called once per frame
    void Update () {
        switch (dir) {
            case direction.RIGHT:
                if (transform.position.x < -stoppingRight)
                    
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case direction.LEFT:
                if (transform.position.x > stoppingRight)
                    transform.Translate(-Vector3.right * speed * Time.deltaTime);
                break;
            case direction.DOWN:
                
                if (transform.position.y > stoppingDown)
                    
                    transform.Translate(-Vector3.up * speed * Time.deltaTime);
                break;
            default:
                Debug.Log("Cant move someones out of the range");
                break;
        }
	}
}