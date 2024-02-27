using UnityEngine;
using UnityEngine.UI;

public class CountdownTextScaler : MonoBehaviour
{
	[Min(0.01f)] public float duration;
	public Vector2 targetSize;

	private RawImage image;	
	private RectTransform rectTransform;

	public void ResetText(Texture texture)
	{
		image.texture = texture;
		rectTransform.sizeDelta = Vector2.zero;
	}

	private void Awake()
	{
		image = GetComponent<RawImage>();
		rectTransform = GetComponent<RectTransform>();
	}

	private void Start() => rectTransform.sizeDelta = Vector2.zero;
	private void Update() => rectTransform.sizeDelta = Vector2.MoveTowards(rectTransform.sizeDelta, targetSize, ValuePerFrame());
	private float ValuePerFrame() => Time.deltaTime*Step();
	private float Step() => targetSize.x / duration;
}