using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;
	public bool inversedDirection;

	private void Update()
	{
		int direction = inversedDirection ? -1 : 1;
		
		transform.Rotate(direction*speed*Time.deltaTime*Vector3.up);
	}
}