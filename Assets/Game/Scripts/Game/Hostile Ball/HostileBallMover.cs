using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HostileBallMover : MonoBehaviour
{
	public Transform patrolPoint;
	[Min(2)] public int amountOfPoints = 2;
	[Min(0f)] public float speed = 10f;
	[Min(1f)] public float radius = 1f;
	[Min(0.1f)] public float distanceTolerance = 1f;
	
	private Rigidbody rb;
	private Transform[] path;
	private int pathPointIndex = 0;
	private bool changedTarget = false;

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void SetInitialPosition() => transform.position = CurrentPathPointPosition();
	private Vector3 CurrentPathPointPosition() => path[pathPointIndex].position;
	private Vector3 PositionHeading(Vector3 position) => (position - transform.position).normalized;
	private bool ReachedPosition(Vector3 position) => Vector3.Distance(transform.position, position) <= distanceTolerance;

	private void Start()
	{
		GeneratePointsAroundPatrolPoint();
		SetInitialPosition();
	}

	private void GeneratePointsAroundPatrolPoint()
	{
		path = new Transform[amountOfPoints];
		
		for (int i = 1; i <= amountOfPoints; ++i)
		{
			GameObject pathPoint = new GameObject("Path Point #" + i);
			
			pathPoint.transform.SetParent(patrolPoint);

			pathPoint.transform.localPosition = PathPointPosition(i);
			path[i - 1] = pathPoint.transform;
		}
	}

	private Vector3 PathPointPosition(int index)
	{
		float radians = index*Mathf.PI*2 / amountOfPoints;
		float x = Mathf.Sin(radians)*radius;
		float y = patrolPoint.position.y;
		float z = Mathf.Cos(radians)*radius;

		return new Vector3(x, y, z);
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
		pathPointIndex = (pathPointIndex + 1) % amountOfPoints;
		changedTarget = true;
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		if(patrolPoint != null)
		{
			Gizmos.DrawWireSphere(patrolPoint.position, radius);
		}
	}
}