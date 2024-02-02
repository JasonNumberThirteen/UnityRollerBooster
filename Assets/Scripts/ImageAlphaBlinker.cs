using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ImageAlphaBlinker : MonoBehaviour
{
	[Min(0.01f)] public float blinkMinInterval = 0.1f, blinkMaxInterval = 1f, blinkDuration = 0.1f;
	[Range(0f, 1f)] public float alphaTarget = 1f;
	
	private Graphic graphic;
	private float initialAlpha, blinkTimer, blinkTimerEnd;

	private void Awake() => graphic = GetComponent<Graphic>();
	private float CurrentAlpha() => graphic.color.a;
	private bool TimerHasNotReachedTheEndYet() => blinkTimer < blinkTimerEnd;
	private void IncreaseTimer() => blinkTimer = Mathf.Clamp(blinkTimer + Time.deltaTime, 0f, blinkTimerEnd);
	private void ResetTimer() => blinkTimer = 0;
	private void SetTimerEnd() => blinkTimerEnd = CurrentAlphaIsTheSameAsInitial() ? BlinkInterval() : blinkDuration;
	private bool CurrentAlphaIsTheSameAsInitial() => CurrentAlpha() == initialAlpha;
	private float BlinkInterval() => Random.Range(blinkMinInterval, blinkMaxInterval);

	private void Start()
	{
		initialAlpha = CurrentAlpha();
		blinkTimerEnd = BlinkInterval();
	}

	private void Update()
	{
		if(TimerHasNotReachedTheEndYet())
		{
			IncreaseTimer();
		}
		else
		{
			SetAlpha();
			ResetTimer();
			SetTimerEnd();
		}
	}

	private void SetAlpha()
	{
		Color color = graphic.color;

		color.a = CurrentAlphaIsTheSameAsInitial() ? alphaTarget : initialAlpha;
		graphic.color = color;
	}
}