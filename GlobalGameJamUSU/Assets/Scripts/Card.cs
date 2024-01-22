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

	public static Card selectedCard;

	public CardType cardType;
	public JokeType jokeType;

	public int attackValue;
	public int defenseValue;

	private void Start()
	{
		gm = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();
	}

	private void OnMouseDown()
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
			Invoke("RemovePlayedCardFromHand", 2f);
		}
	}

	void RemovePlayedCardFromHand()
	{
		gm.discardPile.Add(this);
		gameObject.SetActive(false);
		GameObject removedEffect = Instantiate(effect, transform.position, Quaternion.identity);
	}

	private IEnumerator MoveAndScaleUp()
	{
		float moveDistance = 4f;  // Adjust the distance to move
		Vector3 originalPosition = transform.position;
		Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;

		Vector3 originalScale = transform.localScale;
		Vector3 targetScale = originalScale * 1.3f; // Adjust the scaling factor

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

	void UseCardAbility()
	{
		//CARD ABILITY BASED ON THE TYPE
	}
}
