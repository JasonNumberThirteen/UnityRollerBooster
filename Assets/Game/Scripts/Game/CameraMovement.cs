using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject target;
	[Min(0.01f)] public float speed = 5f;
	public float minimumY;

	private Vector3 offset;
	
	private void Start() => offset = transform.position - target.transform.position;
	
	private void FixedUpdate()
	{
		if(target.transform.position.y <= minimumY)
		{
			return;
		}
		
		Vector3 lerpedPosition = Vector3.Lerp(transform.position, target.transform.position + offset, Time.fixedDeltaTime*speed);

		transform.position = lerpedPosition;
	}
}