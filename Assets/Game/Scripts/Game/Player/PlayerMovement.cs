using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[Min(0f)] public float movementSpeed = 10f;

	private PlayerInput input;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		input = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		Vector2 movement = input.MovementVector;
		Vector3 direction = new Vector3(movement.x, 0.0f, movement.y);

		rb.AddForce(direction*movementSpeed);
	}
}