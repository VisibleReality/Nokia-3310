using System;
using UnityEngine;

public class PatrollingEnemyBehaviour : MonoBehaviour
{
	public Vector2 movementVector;

	[SerializeField] private SpriteRenderer thisRenderer;
	[SerializeField] private Rigidbody2D rb;

	private void Start()
	{
		if (rb == null)
		{
			rb = gameObject.GetComponent<Rigidbody2D>();
		}
		if (thisRenderer == null)
		{
			thisRenderer = gameObject.GetComponent<SpriteRenderer>();
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movementVector * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			// Hit the player
			other.gameObject.GetComponent<PlayerBehaviour>().Hit();
		}
		else if (other.CompareTag("Attack") || other.CompareTag("Enemy") || other.CompareTag("Hazard"))
		{
			return;
		}
		else
		{
			// Turn around
			movementVector *= -1;
			thisRenderer.flipX = !thisRenderer.flipX;
		}
	}
}
