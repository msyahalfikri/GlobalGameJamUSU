using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public List<Card> deck = new List<Card>();
	public List<Card> discardPile = new List<Card>();
	private int roundCounter = 1;
	public TextMeshProUGUI deckSizeText;
	public TextMeshProUGUI turnText;
	public TextMeshProUGUI roundText;
	public GameObject endGameScreen;

	public EnemyHealthPointScript enemyHealthPoint;
	public PlayerHealthPointScript playerHealthPoint;

	public Button DrawButton;
	public Button EndTurnButton;

	public Transform[] cardSlots;
	public bool[] availableCardSlots;

	private Animator camAnim;

	public event Action SwitchTurnsEvent;
	public TurnMechanicScript turnMechanic;

	[HideInInspector] public CardType playerChosenCardType;
	[HideInInspector] public JokeType playerChosenCardJokeType;
	[HideInInspector] public int playerCardAttackValue;
	[HideInInspector] public int playerCardDefenseValue;
	[HideInInspector] public int playerEffectCardEffect;
	[HideInInspector] public int playerChosenCardID;
	[HideInInspector] public int playerMultiplier;


	[HideInInspector] public CardType enemyChosenCardType;
	[HideInInspector] public JokeType enemyChosenCardJokeType;
	[HideInInspector] public int enemyCardAttackValue;
	[HideInInspector] public int enemyCardDefenseValue;
	[HideInInspector] public int enemyEffectCardEffect;
	[HideInInspector] public int enemyChosenCardID;
	[HideInInspector] public int enemyMultiplier;



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
		if (turnMechanic.currentTurn == PlayerTurn.Player)
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
		playerCardDefenseValue = 0;
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
			turnText.text = ("Hasilnya...");
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

		bool allSlotsOccupied = Array.TrueForAll(availableCardSlots, slot => !slot);
		DrawButton.interactable = !allSlotsOccupied;

		// Debug.Log("Enemy Attack: " + enemyCardAttackValue + " || + Enemy Defense Value: " + enemyCardDefenseValue);
	}

	public void SwitchTurnToOpponentEvent()
	{
		SwitchTurnsEvent?.Invoke();
		if (turnMechanic.currentTurn == PlayerTurn.Player)
		{
			roundCounter++;
		}
	}

	private void OnEnable()
	{
		// Subscribe to the DeathEvent
		enemyHealthPoint.EnemyLoseEvent += HandleEnemyLose;
		playerHealthPoint.PlayerLoseEvent += HandlePlayerLose;
	}

	private void OnDisable()
	{
		// Unsubscribe from the DeathEvent when the script is disabled
		enemyHealthPoint.EnemyLoseEvent -= HandleEnemyLose;
		playerHealthPoint.PlayerLoseEvent -= HandlePlayerLose;
	}
	public void HandleEnemyLose()
	{
		endGameScreen.SetActive(true);
	}

	public void HandlePlayerLose()
	{
		endGameScreen.SetActive(true);
	}

	public void BackToMainMenuScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
