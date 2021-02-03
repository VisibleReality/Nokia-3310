using System;
using System.Security.Cryptography;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
	// Destroy self after 0.125 seconds
	private void Start()
	{
		Destroy(gameObject, 0.125f);
	}

	// Kill any enemies which touch the sword
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
		}
	}
}
