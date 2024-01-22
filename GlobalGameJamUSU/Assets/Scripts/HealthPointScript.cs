using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointScript : MonoBehaviour
{
    public float maxHealth = 100f; // Adjust the maximum health value as needed
    private float currentHealth;

    // Event triggered when the object takes damage
    public delegate void OnDamageTaken(float damage);
    public event OnDamageTaken DamageTakenEvent;

    // Event triggered when the object dies
    public delegate void OnDeath();
    public event OnDeath DeathEvent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Trigger the damage taken event
        DamageTakenEvent?.Invoke(damage);

        // Check if the health has reached zero
        if (currentHealth <= 0)
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
}
