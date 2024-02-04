using UnityEngine;

public class CountdownTextScaler : MonoBehaviour
{
	[Min(0.01f)] public float duration;
	public Vector2 targetSize;
	
	private RectTransform rectTransform;

	private void Awake() => rectTransform = GetComponent<RectTransform>();
	private void Start() => rectTransform.sizeDelta = Vector2.zero;
	private void Update() => rectTransform.sizeDelta = Vector2.MoveTowards(rectTransform.sizeDelta, targetSize, ValuePerFrame());
	private float ValuePerFrame() => Time.deltaTime*Step();
	private float Step() => targetSize.x / duration;
}