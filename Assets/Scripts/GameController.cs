using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			Debug.Log("QUIT");
			Application.Quit();
		}
	}
}
