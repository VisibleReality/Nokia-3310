
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform playerTransform;
	public Vector3 offset = new Vector3(0, 0, -10);

	// Update is called once per frame
	void Update()
	{
		transform.position = playerTransform.position + offset;
	}
}
