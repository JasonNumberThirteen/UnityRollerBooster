using TMPro;
using UnityEngine;

public class RaceTimerCounter : MonoBehaviour
{
	public RaceTimer timer;
	public TextMeshPro counter;

	private void Update() => counter.text = string.Format("{0:F1}", timer.CurrentTime);
}