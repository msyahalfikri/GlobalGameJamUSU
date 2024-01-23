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
	public TextMeshProUGUI deckSizeText;
	public TextMeshProUGUI turnText;

	public Button DrawButton;
	public Button EndTurnButton;

	public Transform[] cardSlots;
	public bool[] availableCardSlots;

	private Animator camAnim;

	public event Action SwitchTurnsEvent;
	public TurnMechanicScript turnMechanic;

	private void Start()
	{
		camAnim = Camera.main.GetComponent<Animator>();
		turnMechanic = GetComponent<TurnMechanicScript>();
	}

	public void DrawCards(int numCardsToDraw)
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
		turnText.text = (turnMechanic.currentTurn.ToString() + " Turn");

		if (turnMechanic.currentTurn == PlayerTurn.EnemyAI)
		{
			DrawButton.interactable = false;
			EndTurnButton.interactable = false;
		}
		else if (turnMechanic.currentTurn == PlayerTurn.Player)
		{
			DrawButton.interactable = true;
			EndTurnButton.interactable = true;
		}

	}

	public void SwitchTurnToOpponentEvent()
	{
		SwitchTurnsEvent?.Invoke();
	}
}
