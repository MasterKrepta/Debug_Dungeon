using System;
using UnityEngine;
using UnityEngine.UI;

public class UdemyBoss : MonoBehaviour, IHasHealth {
    [SerializeField] Slider healthBar;
    public float MaxHealth {get; set; }
    public float CurrentHealth { get; set; }

    SpawnWave spawnWave;

    public void Damage(float dmg) {
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
        //TODO update score and move to next wave
        Debug.Log("bossDied");
        spawnWave.ClearBossWave();
        spawnWave.SpawnNewEnemies();
    }

    // Use this for initialization
    void Start () {
        spawnWave = GameObject.FindObjectOfType<SpawnWave>();
        healthBar = GetComponentInChildren<Slider>();
        MaxHealth = 10;
        CurrentHealth = MaxHealth;

        //ClearAllEnemies();
    }

    private void ClearAllEnemies() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies) {
            Destroy(enemy.gameObject);
        }
        //spawnWave.enemyCount = 1;
    }
}
