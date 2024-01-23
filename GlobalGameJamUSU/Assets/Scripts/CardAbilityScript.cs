using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityScript : MonoBehaviour
{
    private Card card;
    public int attackValue;
    public int defenseValue;
    public bool absoluteDefense;
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
            //DealDamage to enemy using event
            BattleMechanicScriptInstance.EnemyTakeDamage(attackValue);
        }
        else if (card.cardType == CardType.Defense)
        {
            if (absoluteDefense == true)
            {

            }
            else
            {

            }

        }
        else if (card.cardType == CardType.Effect)
        {

        }
    }
}
