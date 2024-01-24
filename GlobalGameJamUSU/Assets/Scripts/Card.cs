using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CardType
{
	Attack,
	Defense,
	Effect,
	// Add more types as needed
}

public enum JokeType
{
	Physical,
	Verbal,
	Neutral,
}
public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;

	[HideInInspector] public GameManager gm;

	private Animator anim;
	private Animator camAnim;

	public GameObject effect;
	public GameObject hollowCircle;

	private bool isAnimating = false;
	private Vector3 originalScale;

	public static Card selectedCard;

	public CardType cardType;
	public JokeType jokeType;

	public int attackValue;
	public int defenseValue;
	public int cardID;
	public int multiplier;
	public int otherEffect;
	public CardAbilityScript cardAbility;

	// Event triggered when player played a card
	// public delegate void OnCardPlayed;
	// public event OnCardPlayed OnCardPlayedEvent;

	private void Start()
	{
		gm = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();
		originalScale = transform.localScale;
	}

	private void OnMouseDown()
	{
		if (gm.turnMechanic.currentTurn == PlayerTurn.Player)
		{
			if (!hasBeenPlayed && !isAnimating)
			{

				selectedCard = this;

				isAnimating = true;

				GameObject clickEffect = Instantiate(hollowCircle, transform.position, Quaternion.identity);
				Destroy(clickEffect, 1f);

				camAnim.SetTrigger("shake");
				anim.SetTrigger("move");

				StartCoroutine(MoveAndScaleUp());
				hasBeenPlayed = true;
				gm.availableCardSlots[handIndex] = true;
				PassPlayerCard(selectedCard.cardType, selectedCard.jokeType, selectedCard.attackValue, selectedCard.defenseValue, selectedCard.cardID, selectedCard.multiplier);
				StartCoroutine(RemovePlayedCardAndUseChosenCardAbility());
				gm.SwitchTurnToOpponentEvent();
			}

		}
	}

	private IEnumerator RemovePlayedCardAndUseChosenCardAbility()
	{
		yield return new WaitForSeconds(7f);
		cardAbility.UsePlayerCardAbility();
		RemovePlayedCardFromHand();
		Debug.Log("Card Ability Used");
		Debug.Log("Player Card: " + selectedCard.cardType + ", " + selectedCard.jokeType + ", " + selectedCard.attackValue + ", " + selectedCard.defenseValue + ", " + selectedCard.cardID + ", " + selectedCard.multiplier);

	}
	public void RemovePlayedCardFromHand()
	{
		GameObject removedEffect = Instantiate(effect, transform.position, Quaternion.identity);
		gm.discardPile.Add(this);
		gameObject.SetActive(false);
	}

	private IEnumerator MoveAndScaleUp()
	{
		float moveDistance = 2f;  // Adjust the distance to move
		Vector3 originalPosition = transform.position;
		Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;

		Vector3 originalScale = transform.localScale;
		Vector3 targetScale = originalScale * 1.35f; // Adjust the scaling factor

		float duration = 0.1f; // Adjust the duration of the animation

		float elapsedTime = 0f;

		while (elapsedTime < duration)
		{
			transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
			transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);

			elapsedTime += Time.deltaTime;
			yield return null;
		}

		transform.position = targetPosition;
		transform.localScale = targetScale;

		isAnimating = false;
	}

	private void OnMouseOver()
	{
		// Scale up or apply any other hover effect
		transform.localScale = originalScale * 1.3f;
	}

	private void OnMouseExit()
	{
		// Reset the scale on hover exit
		transform.localScale = originalScale;
	}

	private void PassPlayerCard(CardType _ChosenCardType, JokeType _ChosenCardJokeType, int _CardAttackValue, int _CardDefenseValue, int _ChosenCardID, int _Multiplier)
	{
		gm.playerChosenCardID = _ChosenCardID;
		gm.playerChosenCardType = _ChosenCardType;
		gm.playerChosenCardJokeType = _ChosenCardJokeType;
		gm.playerCardAttackValue = _CardAttackValue;
		gm.playerCardDefenseValue = _CardDefenseValue;
		gm.playerMultiplier = _Multiplier;
	}

}
