using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleMechanicScript : MonoBehaviour
{
    public static BattleMechanicScript Instance;
    private GameManager gm;
    public EnemyAI enemyAI;
    public CardType PlayerCardType;

    public event Action<int, int, int> EnemyTakeDamageEvent;
    public event Action<int, int, int> PlayerTakeDamageEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    public void EnemyTakeDamage(int damage, int reduction, int multiplier)
    {
        EnemyTakeDamageEvent?.Invoke(damage, reduction, multiplier);
    }

    public void PlayerTakeDamage(int damage, int reduction, int multiplier)
    {
        PlayerTakeDamageEvent?.Invoke(damage, reduction, multiplier);
    }
}
