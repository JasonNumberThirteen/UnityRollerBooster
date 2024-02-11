using UnityEngine;

public class CameraPointer : MonoBehaviour
{
	public Transform target;
	[Min(0.01f)] public float speed;

	private void Update()
	{
		transform.LookAt(target);
		transform.RotateAround(target.position, Vector3.up, Time.deltaTime*speed);
	}
}