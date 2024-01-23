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

        // Call a method to begin the first turn (e.g., draw initial cards)
        BeginTurn();
    }

    private void Update()
    {
        Debug.Log(currentTurn);
    }

    public void SwitchTurns()
    {
        // Switch to the next player's turn
        currentTurn = (currentTurn == PlayerTurn.Player) ? PlayerTurn.EnemyAI : PlayerTurn.Player;

        // Call a method to begin the new turn (e.g., draw cards, reset actions)
        BeginTurn();
    }

    private void BeginTurn()
    {
        Debug.Log("It's now " + currentTurn.ToString() + "'s turn.");

        // Add logic for the start of a new turn, such as drawing cards, resetting actions, etc.
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
