using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public List<Card> deck = new List<Card>();
	public List<Card> discardPile = new List<Card>();
	private int roundCounter = 1;
	public TextMeshProUGUI deckSizeText;
	public TextMeshProUGUI turnText;
	public TextMeshProUGUI roundText;

	public Button DrawButton;
	public Button EndTurnButton;

	public Transform[] cardSlots;
	public bool[] availableCardSlots;

	private Animator camAnim;

	public event Action SwitchTurnsEvent;
	public TurnMechanicScript turnMechanic;

	public CardType playerChosenCardType;
	public JokeType playerChosenCardJokeType;
	public int playerCardAttackValue;
	public int playerCardDefenseValue;
	public int playerEffectCardEffect;


	public CardType enemyChosenCardType;
	public JokeType enemyChosenCardJokeType;
	public int enemyCardAttackValue;
	public int enemyCardDefenseValue;
	public int enemyEffectCardEffect;


	private void Start()
	{
		camAnim = Camera.main.GetComponent<Animator>();
		turnMechanic = GetComponent<TurnMechanicScript>();
	}

	public void DrawCard(int numCardsToDraw)
	{
		if (deck.Count >= numCardsToDraw)
		{
			camAnim.SetTrigger("shake");

			for (int drawCount = 0; drawCount < numCardsToDraw; drawCount++)
			{
				Card randomCard = deck[UnityEngine.Random.Range(0, deck.Count)];

				for (int i = 0; i < availableCardSlots.Length; i++)
				{
					if (availableCardSlots[i])
					{
						randomCard.gameObject.SetActive(true);
						randomCard.handIndex = i;
						randomCard.transform.position = cardSlots[i].position;
						randomCard.hasBeenPlayed = false;
						deck.Remove(randomCard);
						availableCardSlots[i] = false;
						break;
					}
				}
			}
		}
	}

	public void DrawSingleOrMultipleCards(int numCardsToDraw)
	{
		if (roundCounter == 1)
		{
			DrawCard(3);
		}
		else
		{
			DrawCard(numCardsToDraw);
			SwitchTurnToOpponentEvent();
		}
	}

	private void Update()
	{
		deckSizeText.text = deck.Count.ToString();
		if (deck.Count <= 0)
		{
			foreach (Card card in discardPile)
			{
				deck.Add(card);
			}
			discardPile.Clear();
		}

		if (turnMechanic.currentTurn == PlayerTurn.EnemyAI)
		{
			turnText.text = ("Membandingkan...");
			DrawButton.interactable = false;
			EndTurnButton.interactable = false;
		}
		else if (turnMechanic.currentTurn == PlayerTurn.Player)
		{
			turnText.text = ("Pilih Kartu Aksi");
			DrawButton.interactable = true;
			EndTurnButton.interactable = true;
		}
		roundText.text = roundCounter.ToString();
	}

	public void SwitchTurnToOpponentEvent()
	{
		SwitchTurnsEvent?.Invoke();
		if (turnMechanic.currentTurn == PlayerTurn.Player)
		{
			roundCounter++;
		}
	}
}
