using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject keyIcon;
	[SerializeField] private Vector3 keyIconPosition = new Vector3(4.5f, -2.5f, 1f);

	[SerializeField] private List<GameObject> healthIcon;
	[SerializeField] private Vector3 healthIconPosition = new Vector3(-3.875f, 2.375f, 1f);

	[SerializeField] private List<GameObject> artifactIcon;
	[SerializeField] private Vector3 artifactIconPosition = new Vector3(4.375f, 2.375f, 1f);
	[SerializeField] private float artifactIconHoldTime = 4f;

	public void SetKeyIcon(bool state)
	{
		var existingIcon = transform.Find("key_ui");

		if (existingIcon != null)
		{
			Destroy(existingIcon.gameObject);
		}

		if (state)
		{
			var thisTransform = transform;
			Instantiate(keyIcon, thisTransform.position + keyIconPosition, quaternion.identity,
				thisTransform).name = "key_ui";
		}
	}

	public void SetHealthIcon(int amount)
	{
		var existingIcon = transform.Find("health_ui");

		if (existingIcon != null)
		{
			Destroy(existingIcon.gameObject);
		}

		var thisTransform = transform;
		Instantiate(healthIcon[amount], thisTransform.position + healthIconPosition,
			quaternion.identity, thisTransform).name = "health_ui";
	}

	public void ShowArtifactIcon(int count)
	{
		var existingIcon = transform.Find("artifact_ui");

		if (existingIcon != null)
		{
			Destroy(existingIcon.gameObject);
		}

		var thisTransform = transform;
		var uiIcon = Instantiate(artifactIcon[count], thisTransform.position + artifactIconPosition,
			quaternion.identity, thisTransform);
		uiIcon.name = "artifact_ui";
		Destroy(uiIcon, artifactIconHoldTime);
	}
}