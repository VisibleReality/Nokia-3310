using System;
using UnityEngine;

public class StaticEnemyBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
			other.gameObject.GetComponent<PlayerBehaviour>().Hit();
		}
	}
}
