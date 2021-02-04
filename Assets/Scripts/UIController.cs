using Unity.Mathematics;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject keyIcon;
	[SerializeField] private Vector3 keyIconPosition = new Vector3(4.5f, -2.5f, 1f);

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
			Instantiate(keyIcon, thisTransform.position + keyIconPosition, quaternion.identity, thisTransform).name = "key_ui";
		}
	}
}