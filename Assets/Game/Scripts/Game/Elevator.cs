using UnityEngine;

public class Elevator : MonoBehaviour
{
	[Min(0.01f)] public float upMovementDuration, downMovementDuration, delay;
	public float differenceY;

	private Vector3 initialPosition, targetPosition;
	private float delayTimer = 0f;
	private bool isGoingUp = true;

	private void Awake() => initialPosition = transform.position;
	private void Start() => targetPosition = TargetPosition();
	private void UpdateTargetPosition() => targetPosition = NextTargetPosition();
	private Vector3 NextTargetPosition() => (targetPosition == initialPosition) ? TargetPosition() : initialPosition;
	private Vector3 TargetPosition() => initialPosition + differenceY*Vector3.up;
	private bool DelayTimerIsElapsed() => delayTimer <= 0;
	private void ReduceDelayTimer() => delayTimer -= Time.deltaTime;
	private bool ReachedTarget() => Vector3.Distance(transform.position, targetPosition) <= Mathf.Epsilon;
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
		isGoingUp = !isGoingUp;

		UpdateTargetPosition();
	}

	private float MovementSpeed()
	{
		float duration = isGoingUp ? upMovementDuration : downMovementDuration;
		float step = differenceY / duration;

		return step*Time.deltaTime;
	}
}