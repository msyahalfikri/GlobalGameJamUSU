using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public TurnMechanicScript turnMechanic;
    public GameManager gm;
    private bool hasChosenCard = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (turnMechanic.currentTurn == PlayerTurn.EnemyAI && !hasChosenCard)
        {
            StartCoroutine(EnemyChoosingCard());
            hasChosenCard = true; // Set the flag to true so that the coroutine is not triggered again until the next turn
        }
    }

    private IEnumerator EnemyChoosingCard()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("CardChosen");
        gm.SwitchTurnToOpponentEvent();
        hasChosenCard = false;
    }

}
