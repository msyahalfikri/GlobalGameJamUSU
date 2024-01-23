using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUIScript : MonoBehaviour
{
    public Image healthBar;
    public Sprite[] CardsOnDeck;
    public Image chosenCard;
    public float healthAmount;
    private EnemyAI enemyAI;
    public EnemyHealthPointScript enemyHP;

    public TextMeshProUGUI enemyHPValueText;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = GetComponent<EnemyHealthPointScript>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void IncreaseHealthBar()
    {
        healthAmount = enemyHP.currentHealth;
        healthBar.fillAmount = (healthAmount / 30f);
        enemyHPValueText.text = (30 - enemyHP.currentHealth).ToString();
    }

    public void SwapEnemyCardImage()
    {
        if (enemyAI.gm.turnMechanic.currentTurn == PlayerTurn.Player)
        {
            chosenCard.sprite = CardsOnDeck[14];
        }
        else
        {
            chosenCard.sprite = CardsOnDeck[enemyAI.ChosenCardID];
        }


    }
    private void Update()
    {
        IncreaseHealthBar();
        SwapEnemyCardImage();
    }
}
