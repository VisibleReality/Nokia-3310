using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
	[SerializeField] private UIController uiController;

	private void Start()
	{
		uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerBehaviour>().hasKey = true;
			Destroy(gameObject);
			uiController.SetKeyIcon(true);
		}
	}
}
