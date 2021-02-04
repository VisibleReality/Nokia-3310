using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public float moveSpeed = 1;
	public Vector3 swordPosition = new Vector3(0f, 0f, 0f);
	public Quaternion swordRotation = new Quaternion(0f, 0f, 0f, 1f);
	public bool hasKey = false;
	
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private GameObject sword;

	private void Start()
	{
		if (rb == null)
		{
			rb = gameObject.GetComponent<Rigidbody2D>();
		}
	}

	private void Update()
	{
		// Set the position and rotation of the sword.
		if (Input.GetKeyDown("w"))
		{
			swordPosition.x = 0f;
			swordPosition.y = 1f;
			swordRotation.z = 0f;
			swordRotation.w = 1f;
		}
		else if (Input.GetKeyDown("s"))
		{
			swordPosition.x = 0f;
			swordPosition.y = -1f;
			swordRotation.z = 1f;
			swordRotation.w = 0f;
		}
		else if (Input.GetKeyDown("d"))
		{
			swordPosition.x = 1f;
			swordPosition.y = 0f;
			swordRotation.z = -0.7f;
			swordRotation.w = 0.7f;
		}
		else if (Input.GetKeyDown("a"))
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
}