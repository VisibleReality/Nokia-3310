using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehaviour : MonoBehaviour
{
	public int artifactsToWin = 3;
	[SerializeField] private UIController uiController;

	private void Start()
	{
		uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			var playerBehaviour = other.GetComponent<PlayerBehaviour>();

			if (playerBehaviour.artifactCount == artifactsToWin)
			{
				SceneManager.LoadScene("End");
			}
			else
			{
				uiController.ShowArtifactCountMessage(playerBehaviour.artifactCount);
			}
		}
	}
}