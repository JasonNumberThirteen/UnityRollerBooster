using TMPro;
using UnityEngine;

public class RaceTimerCounter : MonoBehaviour
{
	public RaceTimer timer;

	private TextMeshProUGUI counter;

	private void Awake() => counter = GetComponent<TextMeshProUGUI>();
	private void Update() => counter.text = Mathf.CeilToInt(timer.CurrentTime).ToString();
}