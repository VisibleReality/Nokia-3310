using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			SceneManager.LoadScene("Title");
		}
	}
}
