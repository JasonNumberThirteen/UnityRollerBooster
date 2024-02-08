using TMPro;
using UnityEngine;

public class RaceTimerCounterColorBlinker : MonoBehaviour
{
	public RaceTimer timer;
	public Color blinkColor = Color.red;
	[Min(0.01f)] public float blinkThreshold = 10f, blinkDuration = 0.5f;

	private TextMeshProUGUI counter;
	private float blinkTimer;
	private Color initialColor;

	private void Awake() => counter = GetComponent<TextMeshProUGUI>();
	private void Start() => initialColor = counter.color;
	private void SetBlinkColor() => counter.color = blinkColor;
	private void SwitchColor() => counter.color = counter.color == initialColor ? blinkColor : initialColor;
	private bool TimeReachedThreshold() => timer.CurrentTime <= blinkThreshold;
	private bool TimerIsElapsed() => blinkTimer <= 0;
	private void ModifyTimer() => blinkTimer -= Time.deltaTime;
	private void ResetTimer() => blinkTimer = blinkDuration;

	private void Update()
	{
		if(RaceManager.instance.stateManager.IsOver())
		{
			SetBlinkColor();
		}
		else if(TimeReachedThreshold())
		{
			if(TimerIsElapsed())
			{
				ResetTimer();
				SwitchColor();
			}
			else
			{
				ModifyTimer();
			}
		}
	}
}