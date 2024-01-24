using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public TurnMechanicScript turnMechanic;
    public GameManager gm;
    public int cardsOnEnemyHand = 3;
    private bool hasMadeAMove = false;
    public CardAbilityScript cardAbility;

    // public int attack_F1 = 1;
    // public int attack_F2 = 1;
    // public int attack_F3 = 1;
    // public int attack_V1 = 1;
    // public int attack_V2 = 1;
    // public int attack_V3 = 1;
    // public int Defense_F1 = 1;
    // public int Defense_F2 = 1;
    // public int Defense_F3 = 1;
    // public int Defense_V1 = 1;
    // public int Defense_V2 = 1;
    // public int Defense_V3 = 1;
    // public int Effect1 = 1;
    // public int Effect2 = 1;


    //0 = Attack, 1 = Defense, 2 = Effect;
    [HideInInspector] public CardType cardType;
    //0 = Physical, 1 = Verbal
    [HideInInspector] public JokeType cardJokeType;
    public int cardAttackValue;
    public int cardDefenseValue;
    public int cardMultiplier;
    public int chosenCardID;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (turnMechanic.currentTurn == PlayerTurn.EnemyAI && !hasMadeAMove)
        {
            StartCoroutine(EnemyMakingAMove());
            hasMadeAMove = true; // Set the flag to true so that the coroutine is not triggered again until the next turn
        }
    }

    private IEnumerator EnemyMakingAMove()
    {
        yield return new WaitForSeconds(4f);
        int randomMove = UnityEngine.Random.Range(0, 3);

        if (randomMove == 0)
        {
            if (cardsOnEnemyHand < 3)
            {
                EnemyDrawsACard();
            }
            else
            {
                EnemyPlaysACard();
            }
        }
        else
        {
            if (cardsOnEnemyHand >= 1)
            {
                EnemyPlaysACard();
            }
            else
            {
                EnemyDrawsACard();
            }
        }

        gm.SwitchTurnToOpponentEvent();
        hasMadeAMove = false;
    }

    private void ChooseRandomCard()
    {
        int chooseRandom = UnityEngine.Random.Range(0, 14);
        switch (chooseRandom)
        {
            case 0:
                chosenCardID = 0;
                break;

            case 1:
                chosenCardID = 1;
                break;

            case 2:
                chosenCardID = 2;
                break;
            case 3:
                chosenCardID = 3;
                break;
            case 4:
                chosenCardID = 4;
                break;
            case 5:
                chosenCardID = 5;
                break;
            case 6:
                chosenCardID = 6;
                break;
            case 7:
                chosenCardID = 7;
                break;
            case 8:
                chosenCardID = 8;
                break;
            case 9:
                chosenCardID = 9;
                break;
            case 10:
                chosenCardID = 10;
                break;
            case 11:
                chosenCardID = 11;
                break;
            case 12:
                chosenCardID = 12;
                break;

            case 13:
                chosenCardID = 13;
                break;

            default:
                chosenCardID = 0;
                break;
        }
    }

    private void EnemyPlaysACard()
    {
        ChooseRandomCard();
        switch (chosenCardID)
        {
            case 0: //Buat Wajah Lucu
                cardType = CardType.Attack;
                cardJokeType = JokeType.Physical;
                cardAttackValue = 2;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;

            case 1: //Gelitik Musuh
                cardType = CardType.Attack;
                cardJokeType = JokeType.Physical;
                cardAttackValue = 1;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;

            case 2://Tunjukin Dank Meme
                cardType = CardType.Attack;
                cardJokeType = JokeType.Physical;
                cardAttackValue = 3;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;
            case 3://Putar Rickroll
                cardType = CardType.Attack;
                cardJokeType = JokeType.Verbal;
                cardAttackValue = 2;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;
            case 4://Cerita trauma
                cardType = CardType.Attack;
                cardJokeType = JokeType.Verbal;
                cardAttackValue = 3;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;
            case 5://Jokes Bapak-Bapak
                cardType = CardType.Attack;
                cardJokeType = JokeType.Verbal;
                cardAttackValue = 1;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;
            case 6://Pura-pura Tidak melihat
                cardType = CardType.Defense;
                cardJokeType = JokeType.Physical;
                cardDefenseValue = -1;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 7://Tiba-tiba Bersin
                cardType = CardType.Defense;
                cardJokeType = JokeType.Physical;
                cardDefenseValue = -2;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 8://Permisi Nelfon
                cardType = CardType.Defense;
                cardJokeType = JokeType.Physical;
                cardDefenseValue = -999;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 9://Pakai Headphone
                cardType = CardType.Defense;
                cardJokeType = JokeType.Verbal;
                cardDefenseValue = -2;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 10://Permisi Ke Kamar Mandi
                cardType = CardType.Defense;
                cardJokeType = JokeType.Verbal;
                cardDefenseValue = -999;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 11://Pura2 Tidak Dengar
                cardType = CardType.Defense;
                cardJokeType = JokeType.Verbal;
                cardDefenseValue = -1;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            case 12://Tonton Siksa Kubur
                cardType = CardType.Effect;
                cardJokeType = JokeType.Neutral;
                cardDefenseValue = 0;
                cardAttackValue = 0;
                cardMultiplier = 1;
                break;
            //laugh bar sendiri -3;

            case 13://Panggil Bantuan Teman
                cardType = CardType.Effect;
                cardJokeType = JokeType.Neutral;
                cardDefenseValue = 0;
                cardAttackValue = 0;
                cardMultiplier = 2;
                break;

            default:
                cardType = CardType.Effect;
                cardJokeType = JokeType.Neutral;
                cardAttackValue = 0;
                cardDefenseValue = 0;
                cardMultiplier = 1;
                break;
        }
        PassEnemyCard(cardType, cardJokeType, cardAttackValue, cardDefenseValue, chosenCardID, cardMultiplier);
        cardsOnEnemyHand--;
        cardAbility.UseCardAbility();
    }

    private void EnemyDrawsACard()
    {
        cardsOnEnemyHand++;
    }

    private void PassEnemyCard(CardType _ChosenCardType, JokeType _ChosenCardJokeType, int _CardAttackValue, int _CardDefenseValue, int _ChosenCardID, int _Multiplier)
    {
        gm.enemyChosenCardID = _ChosenCardID;
        gm.enemyChosenCardType = _ChosenCardType;
        gm.enemyChosenCardJokeType = _ChosenCardJokeType;
        gm.enemyCardAttackValue = _CardAttackValue;
        gm.enemyCardDefenseValue = _CardDefenseValue;
        gm.enemyMultiplier = _Multiplier;
    }
}
