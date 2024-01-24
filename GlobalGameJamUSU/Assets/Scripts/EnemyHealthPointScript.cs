using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPointScript : MonoBehaviour
{
    public float maxHealth = 0f; // Adjust the maximum health value as needed
    public float currentHealth;

    // // Event triggered when the object takes damage
    // public delegate void OnDamageTaken(float damage);
    // public event OnDamageTaken DamageTakenEvent;

    // Event triggered when the object dies
    public delegate void OnEnemyLose();
    public event OnEnemyLose EnemyLoseEvent;
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
    public void TakeDamage(int damage, int reduction, int multiplier, int cardID)
    {
        float finalDamage = (damage + reduction) * multiplier;
        Debug.Log("Damage to Enemy: (" + damage + " + " + reduction + ") * " + multiplier + " = " + finalDamage);
        if (finalDamage < 0)
        {
            finalDamage = 0;
        }
        currentHealth += finalDamage;

        // Check if the health has reached zero
        if (currentHealth >= 30f)
        {
            EnemyLose();
        }
    }

    // Function to handle death (can be expanded based on your game logic)
    private void EnemyLose()
    {
        // Trigger the death event
        EnemyLoseEvent?.Invoke();
    }
    private void Update()
    {
        // Debug.Log(currentHealth);
    }
}
