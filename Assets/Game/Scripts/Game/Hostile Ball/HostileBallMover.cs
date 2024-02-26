using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HostileBallPatrolPathBuilder))]
public class HostileBallMover : MonoBehaviour
{
	[Min(0f)] public float speed = 10f;
	[Min(0.1f)] public float distanceTolerance = 1f;

	public Transform Target {get; set;}
	
	private Rigidbody rb;
	private int pathPointIndex = 0;
	private bool changedTarget = false;
	private HostileBallPatrolPathBuilder patrolPathBuilder;

	private void SetInitialPosition() => transform.position = CurrentPathPointPosition();
	private void UpdateTargetAsNextPathPoint() => Target = patrolPathBuilder.Path[pathPointIndex];
	private Vector3 CurrentPathPointPosition() => patrolPathBuilder.Path[pathPointIndex].position;
	private Vector3 PositionHeading() => (Target.position - transform.position).normalized;
	private bool ReachedPosition() => Vector3.Distance(transform.position, Target.position) <= distanceTolerance;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
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
			AddForceTowardsTarget();
			DisableTargetChange();
		}
		else if(!changedTarget)
		{
			SetNextPathPoint();
		}
	}

	private void AddForceTowardsTarget()
	{
		Vector3 heading = PositionHeading();

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

		UpdateTargetAsNextPathPoint();
	}
}