using UnityEngine;

public class CountdownTextShaker : MonoBehaviour
{
	[Min(0.01f)] public float oscillation = 10f, periodOfOscillation = 0.1f;
	
	private RectTransform rectTransform;
	private Vector2 startPosition;

	private void Awake() => rectTransform = GetComponent<RectTransform>();
	private void Start() => startPosition = rectTransform.anchoredPosition;
	private void Update() => rectTransform.anchoredPosition = ShakePosition();
	private float Angle() => Time.time*Mathf.PI / periodOfOscillation*2;
	private float MovementX(float angle) => Mathf.Cos(angle)*oscillation;
	private float MovementY(float angle) => Mathf.Sin(angle)*oscillation;
	
	private Vector2 ShakePosition()
	{
		float angle = Angle();
		float x = startPosition.x + MovementX(angle);
		float y = startPosition.y + MovementY(angle);

		return new Vector2(x, y);
	}
}