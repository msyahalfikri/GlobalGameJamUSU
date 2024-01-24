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

    public GameObject enemyStraightSprite;
    public GameObject enemySmileSprite;
    public GameObject enemyLaughSprite;

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
            chosenCard.sprite = CardsOnDeck[enemyAI.chosenCardID];
        }
    }

    private void SwapEnemySprite()
    {
        if (enemyHP.currentHealth <= 10)
        {
            enemyStraightSprite.SetActive(true);
            enemySmileSprite.SetActive(false);
            enemyLaughSprite.SetActive(false);

        }
        else if (enemyHP.currentHealth >= 11 && enemyHP.currentHealth <= 29)
        {
            enemyStraightSprite.SetActive(false);
            enemySmileSprite.SetActive(true);
            enemyLaughSprite.SetActive(false);
        }
        else if (enemyHP.currentHealth >= 30)
        {
            enemyStraightSprite.SetActive(false);
            enemySmileSprite.SetActive(false);
            enemyLaughSprite.SetActive(true);
        }


    }
    private void Update()
    {
        IncreaseHealthBar();
        SwapEnemyCardImage();
        SwapEnemySprite();
    }
}