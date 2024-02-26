using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HostileBallPatrolPathBuilder))]
public class HostileBallMover : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;
	[Min(0.1f)] public float distanceTolerance = 1f;
	
	private Rigidbody rb;
	private int pathPointIndex = 0;
	private bool changedTarget = false;
	private HostileBallPatrolPathBuilder patrolPathBuilder;

	private void Start() => SetInitialPosition();
	private void SetInitialPosition() => transform.position = CurrentPathPointPosition();
	private Vector3 CurrentPathPointPosition() => patrolPathBuilder.Path[pathPointIndex].position;
	private Vector3 PositionHeading(Vector3 position) => (position - transform.position).normalized;
	private bool ReachedPosition(Vector3 position) => Vector3.Distance(transform.position, position) <= distanceTolerance;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		patrolPathBuilder = GetComponent<HostileBallPatrolPathBuilder>();
	}

	private void FixedUpdate()
	{
		Vector3 target = CurrentPathPointPosition();
		
		if(!ReachedPosition(target))
		{
			AddForceTowardsPosition(target);
			DisableTargetChange();
		}
		else if(!changedTarget)
		{
			SetNextPathPoint();
		}
	}

	private void AddForceTowardsPosition(Vector3 position)
	{
		Vector3 heading = PositionHeading(position);

		rb.AddForce(heading*speed);
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
	}
}