using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    PlayerManager player;

    Vector3 startingPos;
    enum direction {LEFT, RIGHT, DOWN};
    direction dir = direction.DOWN;
    [SerializeField] float speed = 2;

    [Header ("Stopping Vars")]
    [Space (5)]
    [SerializeField]int stoppingRight = 3;
    [SerializeField]int stoppingDown = -2;


    [Header("Attacking")]
    [Space(10)]
    [SerializeField] float attackTime = 3f;
    [SerializeField] float damage = 1f;
    float timeSinceLastAttack = 0;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerManager>();
        startingPos = transform.position;
        DetermineDirection();
    }

    private void DetermineDirection() {
        startingPos.x = Mathf.Floor(startingPos.x);
        startingPos.y = Mathf.Floor(startingPos.y);
        if (startingPos.x < 0) {
            dir = direction.RIGHT;
            startingPos.y = 0;
            //!Pay attantion to this change
            attackTime += 1;
        }
        else if (startingPos.x > 0) {
            dir =direction.LEFT;
            startingPos.y = 0;
        }
        else if (startingPos.y > 0) {
            dir = direction.DOWN;
            startingPos.x = 0;
            //!Pay attantion to this change
            attackTime += 2;
        }
        else {
            Debug.Log("DEFAULTNG DOWN");
            dir = direction.DOWN;
        }
    }

    // Update is called once per frame
    void Update () {
        Move();
    }

    private void UpdateTimer() {
        if (timeSinceLastAttack < attackTime) {
            timeSinceLastAttack += Time.deltaTime;
        }
        else {
            timeSinceLastAttack = 0;
            player.Damage(damage);
        }
    }

    private void Move() {
        switch (dir) {
            case direction.RIGHT:
                if (transform.position.x < -stoppingRight) {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                } else {
                    UpdateTimer();
                }
                break;
            case direction.LEFT:
                if (transform.position.x > stoppingRight) {
                    transform.Translate(-Vector3.right * speed * Time.deltaTime);
                } else {
                    UpdateTimer();
                }
                break;
            case direction.DOWN:
                if (transform.position.y > stoppingDown) {
                    transform.Translate(-Vector3.up * speed * Time.deltaTime);
                } else {
                    UpdateTimer();
                }
                break;
            default:
                Debug.Log("Cant move someones out of the range");
                break;
        }
    }
}