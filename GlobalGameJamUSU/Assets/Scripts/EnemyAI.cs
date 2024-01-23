using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public TurnMechanicScript turnMechanic;
    public GameManager gm;
    public int cardsOnEnemyHand = 3;
    private bool hasMadeAMove = false;

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
    public int CardType;
    //0 = Physical, 1 = Verbal
    public int CardElement;
    public int CardAttackValue;
    public int CardDefenseValue;


    public int ChosenCardID;

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
                ChosenCardID = 0;
                break;

            case 1:
                ChosenCardID = 1;
                break;

            case 2:
                ChosenCardID = 2;
                break;
            case 3:
                ChosenCardID = 3;
                break;
            case 4:
                ChosenCardID = 4;
                break;
            case 5:
                ChosenCardID = 5;
                break;
            case 6:
                ChosenCardID = 6;
                break;
            case 7:
                ChosenCardID = 7;
                break;
            case 8:
                ChosenCardID = 8;
                break;
            case 9:
                ChosenCardID = 9;
                break;
            case 10:
                ChosenCardID = 10;
                break;
            case 11:
                ChosenCardID = 11;
                break;
            case 12:
                ChosenCardID = 12;
                break;

            case 13:
                ChosenCardID = 13;
                break;

            default:
                ChosenCardID = 0;
                break;
        }
    }

    private void EnemyPlaysACard()
    {
        ChooseRandomCard();
        switch (ChosenCardID)
        {
            case 0: //Buat Wajah Lucu
                CardType = 0;
                CardElement = 0;
                CardAttackValue = 2;
                break;

            case 1: //Gelitik Musuh
                CardType = 0;
                CardElement = 0;
                CardAttackValue = 1;
                break;

            case 2://Tunjukin Dank Meme
                CardType = 0;
                CardElement = 0;
                CardAttackValue = 3;
                break;
            case 3://Putar Rickroll
                CardType = 0;
                CardElement = 1;
                CardAttackValue = 2;
                break;
            case 4://Cerita trauma
                CardType = 0;
                CardElement = 1;
                CardAttackValue = 3;
                break;
            case 5://Jokes Bapak-Bapak
                CardType = 0;
                CardElement = 1;
                CardAttackValue = 1;
                break;
            case 6://Pura-pura Tidak melihat
                CardType = 1;
                CardElement = 0;
                CardDefenseValue = -1;
                break;
            case 7://Tiba-tiba Bersin
                CardType = 1;
                CardElement = 0;
                CardDefenseValue = -2;
                break;
            case 8://Permisi Nelfon
                CardType = 1;
                CardElement = 0;
                CardDefenseValue = -999;
                break;
            case 9://Pakai Headphone
                CardType = 1;
                CardElement = 1;
                CardDefenseValue = -2;
                break;
            case 10://Permisi Ke Kamar Mandi
                CardType = 1;
                CardElement = 1;
                CardDefenseValue = -999;
                break;
            case 11://Pura2 Tidak Dengar
                CardType = 2;
                CardElement = 1;
                CardDefenseValue = -1;
                break;
            case 12://Tonton Siksa Kubur
                CardType = 2;
                //laugh bar sendiri -3;
                break;

            case 13://Panggil Bantuan Teman
                CardType = 2;
                //buff damage x2
                break;

            default:
                CardType = 0;
                CardElement = 0;
                CardAttackValue = 0;
                CardDefenseValue = 0;
                break;
        }
        cardsOnEnemyHand--;
        Debug.Log("Enemy Play Card: " + CardType + "with element: " + CardElement);
    }

    private void EnemyDrawsACard()
    {
        cardsOnEnemyHand++;
        Debug.Log("Enemy Draws a card!");
    }
}
