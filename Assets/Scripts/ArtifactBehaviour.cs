using System;
using UnityEngine;

public class ArtifactBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
			other.GetComponent<PlayerBehaviour>().GainArtifact();
			Destroy(gameObject); // Destroy self after collection
		}
	}
}
