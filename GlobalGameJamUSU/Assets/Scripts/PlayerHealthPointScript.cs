using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPointScript : MonoBehaviour
{
    public float maxHealth = 0f; // Adjust the maximum health value as needed
    public float currentHealth;

    // Event triggered when the object dies
    public delegate void OnDeath();
    public event OnDeath DeathEvent;
    public BattleMechanicScript BattleMechanicScriptInstance;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        BattleMechanicScriptInstance.EnemyTakeDamageEvent += TakeDamage;
    }

    private void OnDisable()
    {
        BattleMechanicScriptInstance.EnemyTakeDamageEvent -= TakeDamage;
    }

    // Function to take damage
    public void TakeDamage(int damage, int reduction, int multiplier)
    {
        float finalDamage = (damage - reduction) * multiplier;
        currentHealth += finalDamage;

        // // Trigger the damage taken event
        // DamageTakenEvent?.Invoke(damage);

        // Check if the health has reached zero
        if (currentHealth >= 30f)
        {
            Die();
        }
    }

    // Function to handle death (can be expanded based on your game logic)
    private void Die()
    {
        // Trigger the death event
        DeathEvent?.Invoke();

        Debug.Log(gameObject.name + " has been defeated!");
        // Perform any actions or animations related to the object being defeated
        Destroy(gameObject); // For simplicity, destroy the object when defeated
    }
    private void Update()
    {
        // Debug.Log(currentHealth);
    }
}
