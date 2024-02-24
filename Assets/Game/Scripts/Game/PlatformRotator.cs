using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;

	private void Update() => transform.Rotate(speed*Time.deltaTime*Vector3.up);
}