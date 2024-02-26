using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HostileBallMover : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;

	public Transform Target {get; set;}
	
	private Rigidbody rb;

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void FixedUpdate() => AddForceTowardsTarget();

	private void AddForceTowardsTarget()
	{
		Vector3 heading = PositionHeading();

		rb.AddForce(heading*speed);
	}

	private Vector3 PositionHeading()
	{
		Vector3 vector = Target.position - transform.position;

		vector.y = 0;

		return vector.normalized;
	}
}