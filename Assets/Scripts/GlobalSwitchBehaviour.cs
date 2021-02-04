using System.Collections.Generic;
using UnityEngine;

public class GlobalSwitchBehaviour : MonoBehaviour
{
	public bool isLocked = true;
	public bool state;
	public List<SwitchboxBehaviour> switchBoxList = new List<SwitchboxBehaviour>();

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite offSprite;
	[SerializeField] private Sprite onSprite;
	[SerializeField] private Collider2D useTrigger;
	[SerializeField] private UIController uiController;

	private void Start()
	{
		uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
	}

	private void Update()
	{
		// When unlocked, pressing h should toggle the switch.
		if (!isLocked && Input.GetKeyDown("h"))
		{
			if (state)
			{
				state = false;
				spriteRenderer.sprite = offSprite;
			}
			else
			{
				state = true;
				spriteRenderer.sprite = onSprite;
			}

			foreach (var box in switchBoxList)
			{
				box.SetState(state);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") && Input.GetKey("h"))
		{
			var playerBehaviour = other.GetComponent<PlayerBehaviour>();
			if (playerBehaviour.hasKey)
			{
				playerBehaviour.hasKey = false;
				uiController.SetKeyIcon(false);
				useTrigger.enabled = false;
				isLocked = false;
				spriteRenderer.sprite = offSprite;
			}
		}
	}
}