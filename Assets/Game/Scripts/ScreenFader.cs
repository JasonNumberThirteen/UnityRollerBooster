using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
	public bool isFadingOut = true;
	[Min(0.01f)] public float duration = 1f;
	
	private RawImage image;

	private void Awake() => image = GetComponent<RawImage>();
	private float AlphaValue() => Mathf.Clamp(image.color.a + ValuePerFrame(), 0f, 1f);
	private float ValuePerFrame() => FadeDirection()*Time.deltaTime / duration;
	private int FadeDirection() => isFadingOut ? -1 : 1;

	private void Update()
	{
		if(AlphaNotReachedTarget())
		{
			ModifyAlpha();
		}
	}

	private bool AlphaNotReachedTarget()
	{
		float target = isFadingOut ? 0f : 1f;
		
		return image.color.a != target;
	}

	private void ModifyAlpha()
	{
		Color color = image.color;

		color.a = AlphaValue();
		image.color = color;
	}
}