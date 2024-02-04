using UnityEngine;

public class RaceTimer : MonoBehaviour
{
	[Min(0f)] public float initialTime;

	public float CurrentTime {get; private set;}

	private void Start() => CurrentTime = initialTime;

	private void Update()
	{
		if(CurrentTime > 0)
		{
			CurrentTime -= Time.deltaTime;
		}
	}
}