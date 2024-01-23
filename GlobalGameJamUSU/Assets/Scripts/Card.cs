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
}
public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;

	GameManager gm;

	private Animator anim;
	private Animator camAnim;

	public GameObject effect;
	public GameObject hollowCircle;

	private bool isAnimating = false;
	private Vector3 originalScale;

	public static Card selectedCard;

	public CardType cardType;
	public JokeType jokeType;
	private CardAbilityScript cardAbility;

	// Event triggered when player played a card
	// public delegate void OnCardPlayed;
	// public event OnCardPlayed OnCardPlayedEvent;

	private void Start()
	{
		gm = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();
		cardAbility = GetComponent<CardAbilityScript>();
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
				cardAbility.UseCardAbility();
				Invoke("RemovePlayedCardFromHand", 2f);
				gm.SwitchTurnToOpponentEvent();
			}
		}
	}

	void RemovePlayedCardFromHand()
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

}
