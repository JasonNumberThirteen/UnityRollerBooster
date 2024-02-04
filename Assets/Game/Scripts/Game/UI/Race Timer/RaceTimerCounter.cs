using TMPro;
using UnityEngine;

public class RaceTimerCounter : MonoBehaviour
{
	public RaceTimer timer;

	private TextMeshProUGUI counter;

	protected virtual string CounterText() => Mathf.FloorToInt(timer.CurrentTime).ToString();

	private void Awake() => counter = GetComponent<TextMeshProUGUI>();
	private void Update() => counter.text = CounterText();
}