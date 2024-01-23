using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleMechanicScript : MonoBehaviour
{
    public static BattleMechanicScript Instance;

    public event Action<float> EnemyTakeDamageEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EnemyTakeDamage(float damage)
    {
        EnemyTakeDamageEvent?.Invoke(damage);
    }
}
