using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[Min(0f)] public float initialTime;

	private float currentTime;

	private void Start() => currentTime = initialTime;

	private void Update()
	{
		if(currentTime > 0)
		{
			currentTime -= Time.deltaTime;
		}
	}
}