using UnityEngine;
using UnityEngine.UI;

public class RectTransformMover : MonoBehaviour
{
	public CanvasScaler canvasScaler;
	[Min(0.01f)] public float duration = 1f, delayBetweenTransitions = 3f;
	public bool startFromLeft;
	
	private RectTransform rectTransform;
	private Vector2 initialPosition;
	private float targetX = 0;
	private bool reachedTarget = false, isGoingLeft;
	private int currentDirection = 1;

	private void DestroySelf() => Destroy(gameObject);
	private void Awake() => rectTransform = GetComponent<RectTransform>();
	private float DifferenceX() => Mathf.Abs(targetX - initialPosition.x);
	private void UpdateInitialPosition() => initialPosition = rectTransform.anchoredPosition;

	private void Start()
	{
		isGoingLeft = startFromLeft;
		
		AssignStartingOffset();
		UpdateInitialPosition();
	}

	private void AssignStartingOffset()
	{
		float width = canvasScaler.referenceResolution.x;
		float x = startFromLeft ? -width : width;

		rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y);
	}

	private void Update()
	{
		Vector2 currentPosition = rectTransform.anchoredPosition;
		float distance = Mathf.Abs(targetX - currentPosition.x);
		float threshold = 2f;

		if(distance > threshold)
		{
			UpdateOffset(currentPosition);
		}
		else if(!reachedTarget)
		{
			reachedTarget = true;
			
			UpdateInitialPosition();
			ResetPosition();
			Invoke(nameof(ChangeTarget), delayBetweenTransitions);
		}
	}

	private void ResetPosition()
	{
		Vector2 position = rectTransform.anchoredPosition;

		position.x = 0;
		rectTransform.anchoredPosition = position;
	}

	private void ChangeTarget()
	{
		float width = canvasScaler.referenceResolution.x;
		
		reachedTarget = false;
		isGoingLeft = !isGoingLeft;
		targetX = isGoingLeft ? width : -width;
		currentDirection = -currentDirection;
		
		Invoke(nameof(DestroySelf), duration);
	}

	private void UpdateOffset(Vector2 currentPosition)
	{
		int direction = isGoingLeft ? 1 : -1;
		
		currentPosition.x += ValuePerFrame()*direction*currentDirection;
		rectTransform.anchoredPosition = currentPosition;
	}

	private float ValuePerFrame()
	{
		float speed = DifferenceX() / duration;
		
		return speed*Time.deltaTime;
	}
}