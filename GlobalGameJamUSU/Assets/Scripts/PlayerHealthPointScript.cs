using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPointScript : MonoBehaviour
{
    public float maxHealth = 0f; // Adjust the maximum health value as needed
    public float currentHealth;

    // Event triggered when the object dies
    public delegate void OnPlayerLose();
    public event OnPlayerLose PlayerLoseEvent;
    public BattleMechanicScript BattleMechanicScriptInstance;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        BattleMechanicScriptInstance.PlayerTakeDamageEvent += TakeDamage;
    }

    private void OnDisable()
    {
        BattleMechanicScriptInstance.PlayerTakeDamageEvent -= TakeDamage;
    }

    // Function to take damage
    public void TakeDamage(int damage, int reduction, int multiplier, int otherEffect)
    {
        float finalDamage = (damage + reduction) * multiplier;
        Debug.Log("Damage to Player: (" + damage + " + " + reduction + ") * " + multiplier + " = " + finalDamage);
        if (finalDamage < 0 || finalDamage > 30)
        {
            finalDamage = 0;
        }
        currentHealth += finalDamage;

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
        PlayerLoseEvent?.Invoke();
    }
    private void Update()
    {
        // Debug.Log(currentHealth);
    }
}
