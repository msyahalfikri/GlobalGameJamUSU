using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMechanicScript : MonoBehaviour
{
    public enum PlayerTurn
    {
        Player,
        EnemyAI
    }

    private PlayerTurn currentTurn;

    private void Start()
    {
        // Start with the first player's turn
        currentTurn = PlayerTurn.Player;

        // Call a method to begin the first turn (e.g., draw initial cards)
        BeginTurn();
    }

    private void Update()
    {
        // Check for end-of-turn conditions (e.g., if the current player has no more actions)

        // For demonstration purposes, switch turns when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTurns();
        }
    }

    private void SwitchTurns()
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
}
