using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityScript : MonoBehaviour
{
    public BattleMechanicScript BattleMechanicScriptInstance;
    public GameManager gm;
    private void Start()
    {
        BattleMechanicScriptInstance = GetComponent<BattleMechanicScript>();
        gm = GetComponent<GameManager>();
    }

    private void Update()
    {

    }

    public void UseCardAbility()
    {
        if (gm.turnMechanic.currentTurn == PlayerTurn.EnemyAI)
        {
            BattleMechanicScriptInstance.PlayerTakeDamage(gm.enemyCardAttackValue, gm.playerCardDefenseValue, gm.enemyMultiplier, gm.enemyChosenCardID);
        }
        else if (gm.turnMechanic.currentTurn == PlayerTurn.Player)
        {
            //DealDamage to enemy using event
            BattleMechanicScriptInstance.EnemyTakeDamage(gm.playerCardAttackValue, gm.enemyCardDefenseValue, gm.playerMultiplier, gm.playerChosenCardID);
        }

    }
}
