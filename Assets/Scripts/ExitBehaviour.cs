using System;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
	public int artifactsToWin = 3;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			var playerBehaviour = other.GetComponent<PlayerBehaviour>();

			if (playerBehaviour.artifactCount == artifactsToWin)
			{
				Debug.Log("You win!");
			}
			else
			{
				Debug.Log($"You have {playerBehaviour.artifactCount} out of {artifactsToWin} artifacts required.");
			}
		}
	}
}