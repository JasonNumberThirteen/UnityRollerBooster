using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HostileBallMover : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;

	public Transform Target {get; set;}
	
	private Rigidbody rb;

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void FixedUpdate() => AddForceTowardsTarget();
	private Vector3 PositionHeading() => (Target.position - transform.position).normalized;

	private void AddForceTowardsTarget()
	{
		Vector3 heading = PositionHeading();

		rb.AddForce(heading*speed);
	}
}