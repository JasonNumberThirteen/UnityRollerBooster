using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[Min(0f)] public float movementSpeed = 10f, dizzySpeedMultiplier = 0.5f, dizzyDuration = 3f, dizzyFallDistance = 3f, deathFallDistance = 5f;

	private Rigidbody rb;
	private PlayerInput input;
	private PlayerRespawner respawner;

	private float velocityY;
	private float currentSpeed;

	public void CheckFallDistance()
	{
		if(velocityY <= -deathFallDistance)
		{
			respawner.RespawnByFall();
		}
		else if(velocityY <= -dizzyFallDistance)
		{
			currentSpeed *= dizzySpeedMultiplier;

			Invoke(nameof(RestoreFullSpeed), dizzyDuration);
		}
	}

	private void Start() => RestoreFullSpeed();
	private void Update() => velocityY = rb.velocity.y;
	private void RestoreFullSpeed() => currentSpeed = movementSpeed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		input = GetComponent<PlayerInput>();
		respawner = GetComponent<PlayerRespawner>();
	}

	private void FixedUpdate()
	{
		Vector2 movement = input.MovementVector;
		Vector3 direction = new Vector3(movement.x, 0.0f, movement.y);

		rb.AddForce(direction*currentSpeed);
	}
}