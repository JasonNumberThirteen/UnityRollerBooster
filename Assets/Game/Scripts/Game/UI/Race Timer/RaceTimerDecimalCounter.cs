using TMPro;
using UnityEngine;

public class RaceTimerDecimalCounter : MonoBehaviour
{
	public RaceTimer timer;

	private TextMeshProUGUI counter;

	private void Awake() => counter = GetComponent<TextMeshProUGUI>();

	private void Update()
	{
		string text = string.Format("{0:F1}", timer.CurrentTime);

		counter.text = text[^2..];
	}
}