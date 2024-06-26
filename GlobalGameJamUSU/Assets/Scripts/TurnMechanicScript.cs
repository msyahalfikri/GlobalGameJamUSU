using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn
{
    Player,
    EnemyAI
}
public class TurnMechanicScript : MonoBehaviour
{
    public PlayerTurn currentTurn;
    public GameManager gm;

    private void Start()
    {
        // Start with the first player's turn
        currentTurn = PlayerTurn.Player;
    }

    private void Update()
    {
        // Debug.Log(currentTurn);
    }

    public void SwitchTurns()
    {
        // Switch to the next player's turn
        currentTurn = (currentTurn == PlayerTurn.Player) ? PlayerTurn.EnemyAI : PlayerTurn.Player;
    }

    private void OnEnable()
    {
        gm.SwitchTurnsEvent += SwitchTurns;
    }

    private void OnDisable()
    {
        gm.SwitchTurnsEvent -= SwitchTurns;
    }

}
