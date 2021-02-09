
using System;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
	[SerializeField] private PlayerBehaviour playerBehaviour;
	[SerializeField] private Transform playerTransform;
	
	private void Start()
	{
		var player = GameObject.Find("Player");
		playerBehaviour = player.GetComponent<PlayerBehaviour>();
		playerTransform = player.transform;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		playerBehaviour.respawnPoint = playerTransform.position;
	}
}
