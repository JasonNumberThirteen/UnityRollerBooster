using UnityEngine;

[RequireComponent(typeof(HostileBallMover))]
[RequireComponent(typeof(HostileBallPatrolPathMovementController))]
public class HostileBallPlayerDetector : MonoBehaviour
{
	public Transform player;
	[Min(0.01f)] public float detectionDistance = 3f;

	private HostileBallMover mover;
	private HostileBallPatrolPathMovementController patrolPathMovementController;

	private bool DetectedPlayer() => Vector3.Distance(transform.position, player.position) <= detectionDistance;
	private void OnLoseSightOfPlayer() => patrolPathMovementController.enabled = true;

	private void Awake()
	{
		mover = GetComponent<HostileBallMover>();
		patrolPathMovementController = GetComponent<HostileBallPatrolPathMovementController>();
	}

	private void Update()
	{
		if(DetectedPlayer())
		{
			OnPlayerDetect();
		}
		else if(!patrolPathMovementController.enabled)
		{
			OnLoseSightOfPlayer();
		}
	}

	private void OnPlayerDetect()
	{
		if(!patrolPathMovementController.enabled)
		{
			return;
		}
		
		mover.Target = player;
		patrolPathMovementController.enabled = false;
	}
}