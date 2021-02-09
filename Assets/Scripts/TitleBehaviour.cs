using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBehaviour : MonoBehaviour
{
	public List<GameObject> slides;
	public Vector3 slidePosition = new Vector3(0f, 0f, 0f);
	public int slideIndex;

	private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		else if (Input.anyKeyDown)
		{
			if (slideIndex == slides.Count)
			{
				SceneManager.LoadScene("Game");
				return;
			}

			// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
			var existingSlide = GameObject.Find("slide");

			// ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
			if (existingSlide != null)
			{
				Destroy(existingSlide.gameObject);
			}

			Instantiate(slides[slideIndex], transform.position + slidePosition, Quaternion.identity).name = "slide";

			slideIndex++;
		}
	}
}