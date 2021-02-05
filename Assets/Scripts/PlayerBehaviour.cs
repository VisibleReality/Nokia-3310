using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public float moveSpeed = 1;
	public Vector3 swordPosition = new Vector3(0f, 0f, 0f);
	public Quaternion swordRotation = new Quaternion(0f, 0f, 0f, 1f);
	public bool hasKey;
	public int fullHp = 3;
	public int hp = 3;
	public Vector3 respawnPoint = new Vector3(0f, 0f, 0f);
	public int artifactCount = 0;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private GameObject sword;
	[SerializeField] private SpriteRenderer thisRenderer;
	[SerializeField] private UIController uiController;

	private void Start()
	{
		if (rb == null)
		{
			rb = gameObject.GetComponent<Rigidbody2D>();
		}

		if (thisRenderer == null)
		{
			thisRenderer = gameObject.GetComponent<SpriteRenderer>();
		}

		if (uiController == null)
		{
			uiController = GameObject.Find("Main Camera").GetComponent<UIController>();
		}
	}

	private void Update()
	{
		// Set the position and rotation of the sword.
		if (Input.GetKey("w"))
		{
			swordPosition.x = 0f;
			swordPosition.y = 1f;
			swordRotation.z = 0f;
			swordRotation.w = 1f;
		}
		else if (Input.GetKey("s"))
		{
			swordPosition.x = 0f;
			swordPosition.y = -1f;
			swordRotation.z = 1f;
			swordRotation.w = 0f;
		}
		else if (Input.GetKey("d"))
		{
			swordPosition.x = 1f;
			swordPosition.y = 0f;
			swordRotation.z = -0.7f;
			swordRotation.w = 0.7f;
		}
		else if (Input.GetKey("a"))
		{
			swordPosition.x = -1f;
			swordPosition.y = 0f;
			swordRotation.z = 0.7f;
			swordRotation.w = 0.7f;
		}

		// Attack with a sword when J is pressed
		if (Input.GetKeyDown("j"))
		{
			var thisTransform = transform;
			Instantiate(sword, thisTransform.position + swordPosition, swordRotation, thisTransform);
		}
	}

	private void FixedUpdate()
	{
		var velocity = new Vector2(0f, 0f);

		if (Input.GetKey("w"))
		{
			velocity.y += moveSpeed;
		}

		if (Input.GetKey("s"))
		{
			velocity.y -= moveSpeed;
		}

		if (Input.GetKey("d"))
		{
			velocity.x += moveSpeed;
		}

		if (Input.GetKey("a"))
		{
			velocity.x -= moveSpeed;
		}

		rb.velocity = velocity;
	}

	private IEnumerator BlinkSprite(int times)
	{
		for (; times != 0; times--)
		{
			thisRenderer.enabled = false;
			yield return new WaitForSeconds(0.1f);
			// ReSharper disable once Unity.InefficientPropertyAccess
			thisRenderer.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void Hit()
	{
		Debug.Log("Hit!");
		StartCoroutine(BlinkSprite(3));
		hp--;
		uiController.SetHealthIcon(hp);
		if (hp == 0)
		{
			Kill();
		}
	}

	private void Kill()
	{
		transform.position = respawnPoint;
		hp = fullHp;
		uiController.SetHealthIcon(fullHp);
	}

	public void GainArtifact()
	{
		artifactCount++;
		uiController.ShowArtifactIcon(artifactCount);
	}
}