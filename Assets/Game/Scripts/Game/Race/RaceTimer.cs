using UnityEngine;

public class RaceTimer : MonoBehaviour
{
	[Min(0f)] public float initialTime;

	public float CurrentTime {get; private set;}

	private void Start() => CurrentTime = initialTime;
	private bool TimeIsNotElapsed() => CurrentTime > 0;
	private void ModifyTime() => CurrentTime = Mathf.Clamp(CurrentTime - Time.deltaTime, 0, CurrentTime);

	private void Update()
	{
		if(TimeIsNotElapsed())
		{
			ModifyTime();
		}
	}
}