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

	private bool _inTrigger;
	private PlayerBehaviour _playerBehaviour;

	private void Start()
	{
		uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
	}

	private void Update()
	{
		if (Input.GetKeyDown("h"))
		{
			if (!isLocked)
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
			else if (_inTrigger)
			{
				if (_playerBehaviour.hasKey)
				{
					_playerBehaviour.hasKey = false;
					// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
					uiController.SetKeyIcon(false);
					useTrigger.enabled = false;
					isLocked = false;
					spriteRenderer.sprite = offSprite;
					// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
					uiController.ShowUnlockMessage();
				}
				else if (!uiController.messageActive)
				{
					// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
					uiController.ShowLockedMessage();
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_inTrigger = true;
			_playerBehaviour = other.GetComponent<PlayerBehaviour>();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_inTrigger = false;
		}
	}
}