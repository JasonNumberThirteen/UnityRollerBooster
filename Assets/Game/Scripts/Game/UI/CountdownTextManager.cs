using UnityEngine;

public class CountdownTextManager : MonoBehaviour
{
	public CountdownText[] texts;
	public CountdownTextScaler textScaler;

	private CountdownText currentText;
	private int textIndex;
	private float durationTimer;

	private void Update()
	{
		if(durationTimer > 0)
		{
			durationTimer -= Time.deltaTime;
		}
		else if(textIndex < texts.Length)
		{
			DisplayNextText();
		}
	}

	private void DisplayNextText()
	{
		currentText = texts[textIndex++];
		textScaler.targetSize = currentText.targetSize;
		durationTimer = currentText.duration;

		textScaler.ResetText(currentText.texture);
	}

	private void Start() => DisplayNextText();
}

[System.Serializable]
public class CountdownText
{
	public Texture texture;
	public Vector2 targetSize;
	[Min(0.01f)] public float duration;
}