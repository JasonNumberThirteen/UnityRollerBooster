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

	private void DestroySelf() => Destroy(gameObject);
	private void Awake() => rectTransform = GetComponent<RectTransform>();
	private float DifferenceX() => Mathf.Abs(targetX - initialPosition.x);
	private void UpdateInitialPosition() => initialPosition = rectTransform.anchoredPosition;
	private bool ReachedTargetPosition() => rectTransform.anchoredPosition == TargetPosition();
	private Vector2 TargetPosition() => new Vector2(targetX, rectTransform.anchoredPosition.y);
	private void SetReachedTarget(bool reached) => reachedTarget = reached;
	private void SetGoingLeft(bool goingLeft) => isGoingLeft = goingLeft;

	private void Start()
	{
		SetGoingLeft(startFromLeft);
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
		if(!ReachedTargetPosition())
		{
			UpdatePosition();
		}
		else if(!reachedTarget)
		{
			SetReachedTarget(true);
			UpdateInitialPosition();
			ResetPosition();
			Invoke(nameof(ChangeTarget), delayBetweenTransitions);
		}
	}

	private void UpdatePosition()
	{
		Vector2 target = TargetPosition();
		float t = SpeedPerFrame();
		
		rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, target, t);
	}

	private float SpeedPerFrame()
	{
		float speed = DifferenceX() / duration;
		
		return speed*Time.deltaTime;
	}

	private void ResetPosition()
	{
		Vector2 position = rectTransform.anchoredPosition;

		position.x = 0;
		rectTransform.anchoredPosition = position;
	}

	private void ChangeTarget()
	{
		SetReachedTarget(false);
		SetGoingLeft(!isGoingLeft);
		UpdateTarget();
		Invoke(nameof(DestroySelf), duration);
	}

	private void UpdateTarget()
	{
		float width = canvasScaler.referenceResolution.x;
		
		targetX = isGoingLeft ? -width : width;
	}
}