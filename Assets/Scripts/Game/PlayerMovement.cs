using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[Min(0f)] public float movementSpeed = 10f;

	private Rigidbody rb;
	private Vector2 movement;

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void OnMove(InputValue iv) => movement = iv.Get<Vector2>();

	private void FixedUpdate()
	{
		Vector3 movementVector = new Vector3(movement.x, 0.0f, movement.y);

		rb.AddForce(movementVector*movementSpeed);
	}
}