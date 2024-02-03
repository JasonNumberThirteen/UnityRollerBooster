using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Shadow))]
public class ShadowMover : MonoBehaviour
{
	[Min(0.01f)] public float oscillation = 1f, periodOfOscillation = 3f;

	private Shadow shadow;
	private Vector2 startDistance;

	private void Awake() => shadow = GetComponent<Shadow>();
	private void Start() => startDistance = shadow.effectDistance;
	private void Update() => shadow.effectDistance = EffectDistance();
	private float Angle() => Time.unscaledTime*Mathf.PI / periodOfOscillation*2;
	private float MovementX(float angle) => Mathf.Sin(-angle)*oscillation;
	private float MovementY(float angle) => Mathf.Sin(angle)*oscillation;

	private Vector2 EffectDistance()
	{
		float angle = Angle();
		float x = startDistance.x + MovementX(angle);
		float y = startDistance.y + MovementY(angle);

		return new Vector2(x, y);
	}
}