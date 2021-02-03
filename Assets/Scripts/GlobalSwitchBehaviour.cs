using System;
using UnityEngine;

public class GlobalSwitchBehaviour : MonoBehaviour
{
	public bool isLocked = true;

	[SerializeField] private Texture2D _offTexture;

	[SerializeField] private Texture2D _onTexture;

	[SerializeField] private Collider2D _useTrigger;

	private void Update()
	{
		
	}
}
