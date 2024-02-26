using UnityEngine;

[RequireComponent(typeof(HostileBallMover))]
[RequireComponent(typeof(HostileBallPatrolPathBuilder))]
public class HostileBallPatrolPathMovementController : MonoBehaviour
{
	[Min(0.1f)] public float distanceTolerance = 1f;
	
	private int pathPointIndex = 0;
	private bool changedTarget = false;
	private HostileBallMover mover;
	private HostileBallPatrolPathBuilder patrolPathBuilder;
	
	private void SetInitialPosition() => transform.position = CurrentPathPointPosition();
	private void UpdateTargetAsNextPathPoint() => mover.Target = patrolPathBuilder.Path[pathPointIndex];
	private Vector3 CurrentPathPointPosition() => patrolPathBuilder.Path[pathPointIndex].position;
	private bool ReachedPosition() => Vector3.Distance(transform.position, mover.Target.position) <= distanceTolerance;

	private void Awake()
	{
		mover = GetComponent<HostileBallMover>();
		patrolPathBuilder = GetComponent<HostileBallPatrolPathBuilder>();
	}

	private void Start()
	{
		SetInitialPosition();
		UpdateTargetAsNextPathPoint();
	}

	private void FixedUpdate()
	{
		if(!ReachedPosition())
		{
			DisableTargetChange();
		}
		else if(!changedTarget)
		{
			SetNextPathPoint();
		}
	}

	private void DisableTargetChange()
	{
		if(changedTarget)
		{
			changedTarget = false;
		}
	}

	private void SetNextPathPoint()
	{
		pathPointIndex = (pathPointIndex + 1) % patrolPathBuilder.amountOfPoints;
		changedTarget = true;

		UpdateTargetAsNextPathPoint();
	}
}