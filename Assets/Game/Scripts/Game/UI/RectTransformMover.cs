using UnityEngine;
using UnityEngine.UI;

public class RectTransformMover : MonoBehaviour
{
	public CanvasScaler canvasScaler;
	public float targetX;
	[Min(0.01f)] public float duration = 1f;
	
	private RectTransform rectTransform;
	private Vector2 initialPosition;
	
	private void Awake() => rectTransform = GetComponent<RectTransform>();
	private float DifferenceX() => Mathf.Abs(targetX - initialPosition.x);

	private void Start()
	{
		rectTransform.offsetMax = new Vector2(-canvasScaler.referenceResolution.x, rectTransform.offsetMax.y);
		initialPosition = rectTransform.offsetMax;
	}

	private void Update()
	{
		Vector2 currentPosition = rectTransform.offsetMax;
		
		if(currentPosition.x < targetX)
		{
			UpdateOffset(currentPosition);
		}
	}

	private void UpdateOffset(Vector2 currentPosition)
	{
		currentPosition.x += ValuePerFrame();
		rectTransform.offsetMax = currentPosition;
	}

	private float ValuePerFrame()
	{
		float speed = DifferenceX() / duration;
		
		return speed*Time.deltaTime;
	}
}