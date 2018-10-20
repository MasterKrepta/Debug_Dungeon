using System;
using UnityEngine;
using UnityEngine.UI;

public class UdemyBoss : MonoBehaviour, IHasHealth {
    [SerializeField] Slider healthBar;
    public float MaxHealth {get; set; }
    public float CurrentHealth { get; set; }

    PlayerManager player;
    SpawnWave spawnWave;
    AudioSource mainMusic;
    

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
        mainMusic.Play();
        spawnWave.ClearBossWave(player);
        spawnWave.SpawnNewEnemies();
    }

    // Use this for initialization
    void Start () {
        mainMusic = GetComponent<AudioSource>();
        
        mainMusic.Stop();
        this.GetComponent<AudioSource>().Play();
        spawnWave = GameObject.FindObjectOfType<SpawnWave>();
        player = FindObjectOfType<PlayerManager>();
        healthBar = GetComponentInChildren<Slider>();
        MaxHealth = 6;
        CurrentHealth = MaxHealth;
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
