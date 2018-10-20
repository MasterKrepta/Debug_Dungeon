using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IHasHealth {

    [SerializeField]Slider healthBar;
    public float MaxHealth {get; set;}
    public float CurrentHealth { get ; set ; }

    
    public void Damage(float dmg) {
        if (CurrentHealth <= 0) {
            //Prevent duplicate calls
            return;
        }
        CurrentHealth -= dmg;
        UpdateDamageUI();
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    private void UpdateDamageUI() {
        float value = CurrentHealth / MaxHealth;
        healthBar.value = value;
    }

    public void Die() {
        ScoreManager.GetPercentages();
        SceneManager.LoadScene(2);

        //
    }

    // Use this for initialization
    void Start () {
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
	}
	
    
}
