using UnityEngine;

public class PlatformMover : MonoBehaviour
{
	[Min(0.01f)] public float movementDuration;
	[Min(0f)] public float delay;
	public Vector3 positionOffset;

	private Vector3 initialPosition, targetPosition;
	private float delayTimer = 0f;

	private void Awake() => initialPosition = transform.position;
	private void Start() => targetPosition = TargetPosition();
	private void UpdatePositions() => (initialPosition, targetPosition) = (targetPosition, initialPosition);
	private Vector3 TargetPosition() => initialPosition + positionOffset;
	private bool DelayTimerIsElapsed() => delayTimer <= 0;
	private void ReduceDelayTimer() => delayTimer -= Time.deltaTime;
	private bool ReachedTarget() => DistanceToTarget(transform.position) <= Mathf.Epsilon;
	private float DistanceToTarget(Vector3 current) => Vector3.Distance(current, targetPosition);
	private void MoveToTarget() => transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed());

	private void Update()
	{
		if(DelayTimerIsElapsed())
		{
			OnDelayTimerElapse();
		}
		else
		{
			ReduceDelayTimer();
		}
	}

	private void OnDelayTimerElapse()
	{
		if(ReachedTarget())
		{
			OnTargetReach();
		}
		else
		{
			MoveToTarget();
		}
	}

	private void OnTargetReach()
	{
		delayTimer = delay;

		UpdatePositions();
	}

	private float MovementSpeed()
	{
		float distance = DistanceToTarget(initialPosition);
		float step = distance / movementDuration;

		return step*Time.deltaTime;
	}
}