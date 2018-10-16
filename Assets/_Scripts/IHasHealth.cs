public interface IHasHealth {

    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }

    void Damage(float dmg);

    void Die();
}
