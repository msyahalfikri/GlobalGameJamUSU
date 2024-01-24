using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityScript : MonoBehaviour
{
    public bool buffNextPlayerAttack = false;
    public bool buffNextEnemyAttack = false;
    public EnemyHealthPointScript enemyHP;
    public PlayerHealthPointScript playerHP;
    public BattleMechanicScript BattleMechanicScriptInstance;
    public GameManager gm;
    public int buffPlayerValue = 0;
    public int buffEnemyValue = 0;
    private void Start()
    {
        BattleMechanicScriptInstance = GetComponent<BattleMechanicScript>();
        gm = GetComponent<GameManager>();
    }

    private void Update()
    {
        // Debug.Log("Player is buffed?: " + buffNextPlayerAttack);
        // Debug.Log("Enemy is buffed?: " + buffNextEnemyAttack);
    }

    public void UsePlayerCardAbility()
    {
        if (gm.playerChosenCardID == 12)
        {
            if (buffNextPlayerAttack == false)
            {
                buffNextPlayerAttack = true;
                buffPlayerValue = gm.playerMultiplier;
            }
        }

        if (gm.playerChosenCardID == 13)
        {
            playerHP.currentHealth -= 3;
        }

        if (gm.playerChosenCardJokeType == gm.enemyChosenCardJokeType)
        {
            if (buffNextPlayerAttack == true)
            {

                BattleMechanicScriptInstance.EnemyTakeDamage(gm.playerCardAttackValue, gm.enemyCardDefenseValue, gm.playerMultiplier * buffPlayerValue, gm.playerChosenCardID);

            }
            else
            {
                BattleMechanicScriptInstance.EnemyTakeDamage(gm.playerCardAttackValue, gm.enemyCardDefenseValue, gm.playerMultiplier, gm.playerChosenCardID);
            }
            buffPlayerValue = 1;
            buffNextPlayerAttack = false;
        }
        else
        {
            if (buffNextPlayerAttack == true)
            {

                BattleMechanicScriptInstance.EnemyTakeDamage(gm.playerCardAttackValue, 0, gm.playerMultiplier * buffPlayerValue, gm.playerChosenCardID);

            }
            else
            {
                BattleMechanicScriptInstance.EnemyTakeDamage(gm.playerCardAttackValue, 0, gm.playerMultiplier, gm.playerChosenCardID);
            }
            buffPlayerValue = 1;
            buffNextPlayerAttack = false;
        }

    }
    public void UseEnemyCardAbility()
    {
        if (gm.enemyChosenCardID == 13)
        {
            if (buffNextEnemyAttack == false)
            {
                buffNextEnemyAttack = true;
                buffEnemyValue = gm.enemyMultiplier;
            }
        }

        if (gm.enemyChosenCardID == 12)
        {
            enemyHP.currentHealth -= 3;
        }

        if (gm.playerChosenCardJokeType == gm.enemyChosenCardJokeType)
        {
            if (buffNextEnemyAttack == true)
            {
                BattleMechanicScriptInstance.PlayerTakeDamage(gm.enemyCardAttackValue, gm.playerCardDefenseValue, gm.enemyMultiplier * buffEnemyValue, gm.enemyChosenCardID);

            }
            else
            {
                BattleMechanicScriptInstance.PlayerTakeDamage(gm.enemyCardAttackValue, gm.playerCardDefenseValue, gm.enemyMultiplier, gm.enemyChosenCardID);
            }
            buffEnemyValue = 1;
            buffNextEnemyAttack = false;
        }
        else
        {
            if (buffNextEnemyAttack == true)
            {
                BattleMechanicScriptInstance.PlayerTakeDamage(gm.enemyCardAttackValue, 0, gm.enemyMultiplier * buffEnemyValue, gm.enemyChosenCardID);
            }
            else
            {
                BattleMechanicScriptInstance.PlayerTakeDamage(gm.enemyCardAttackValue, 0, gm.enemyMultiplier, gm.enemyChosenCardID);
            }
            buffEnemyValue = 1;
            buffNextEnemyAttack = false;
        }


    }
}
