using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			SceneManager.LoadScene("Title");
		}
	}
}
