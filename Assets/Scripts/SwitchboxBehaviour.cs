using UnityEngine;

public class SwitchboxBehaviour : MonoBehaviour
{

	public bool blockType = true;
	public bool state;

	[SerializeField] private Sprite solidSprite;
	[SerializeField] private Sprite passthroughSprite;
	[SerializeField] private Collider2D thisCollider;
	[SerializeField] private SpriteRenderer spriteRenderer;
	
	public void Start()
	{
		thisCollider = gameObject.GetComponent<Collider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		// Add self to list of boxes held by the switch
		GameObject.Find("Switch").GetComponent<GlobalSwitchBehaviour>().switchBoxList.Add(this);
	}
	
	public void SetState(bool newState)
	{
		if (!blockType)
		{
			newState = !newState;
		}
		
		if (newState)
		{
			spriteRenderer.sprite = passthroughSprite;
			thisCollider.enabled = false;
			state = false;
		}
		else
		{
			spriteRenderer.sprite = solidSprite;
			thisCollider.enabled = true;
			state = true;
		}
	}
}
