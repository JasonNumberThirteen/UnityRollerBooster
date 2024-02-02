using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject target;
	[Min(0.01f)] public float speed = 5f;

	private Vector3 offset;
	
	private void Start() => offset = transform.position - target.transform.position;
	
	private void FixedUpdate()
	{
		Vector3 lerpedPosition = Vector3.Lerp(transform.position, target.transform.position + offset, Time.fixedDeltaTime*speed);
		
		transform.position = lerpedPosition;
	}
}