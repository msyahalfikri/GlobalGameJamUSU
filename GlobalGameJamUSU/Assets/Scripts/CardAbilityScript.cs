using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityScript : MonoBehaviour
{
    private Card card;
    public int attackValue;
    public int defenseValue;
    public int multiplier;
    public static BattleMechanicScript BattleMechanicScriptInstance;
    private void Start()
    {
        card = GetComponent<Card>();
        BattleMechanicScriptInstance = FindObjectOfType<BattleMechanicScript>();
    }

    private void Update()
    {

    }

    public void UseCardAbility()
    {
        if (card.cardType == CardType.Attack)
        {
            if (card.gm.turnMechanic.currentTurn == PlayerTurn.EnemyAI)
            {

            }
            else if (card.gm.turnMechanic.currentTurn == PlayerTurn.Player)
            {
                //DealDamage to enemy using event
                BattleMechanicScriptInstance.EnemyTakeDamage(attackValue, defenseValue, multiplier);
            }

        }
        else if (card.cardType == CardType.Defense)
        {

        }
        else if (card.cardType == CardType.Effect)
        {

        }
    }
}
