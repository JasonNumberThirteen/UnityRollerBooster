using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject target;
	[Min(0.01f)] public float speed = 5f;
	public float minimumY;

	private Vector3 offset;
	
	private void Start() => offset = transform.position - target.transform.position;
	private bool TargetMustBeTracked() => target.transform.position.y > minimumY;
	
	private void FixedUpdate()
	{
		if(TargetMustBeTracked())
		{
			UpdatePosition();
		}
	}

	private void UpdatePosition()
	{
		float t = Time.fixedDeltaTime*speed;
		Vector3 targetPosition = target.transform.position + offset;
		Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, t);

		transform.position = newPosition;
	}
}