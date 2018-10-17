using System;
using UnityEngine;
using UnityEngine.UI;

public class UdemyBoss : MonoBehaviour, IHasHealth {
    [SerializeField] Slider healthBar;
    public float MaxHealth {get; set; }
    public float CurrentHealth { get; set; }

    PlayerManager player;
    SpawnWave spawnWave;


    [Header("Attacking")]
    [Space(10)]
    [SerializeField] float attackTime = 3f;
    [SerializeField] float damage = 1f;
    float timeSinceLastAttack = 0;

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
        spawnWave.ClearBossWave(player);
        spawnWave.SpawnNewEnemies();
    }

    // Use this for initialization
    void Start () {
        spawnWave = GameObject.FindObjectOfType<SpawnWave>();
        player = FindObjectOfType<PlayerManager>();
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

    private void Update() {
        UpdateTimer();
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
}
