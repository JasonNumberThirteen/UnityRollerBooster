using UnityEngine;

public class HostileBallPatrolPathBuilder : MonoBehaviour
{
	public Transform patrolPoint;
	[Min(2)] public int amountOfPoints = 2;
	[Min(1f)] public float radius = 1f;

	public Transform[] Path {get; private set;}

	private void Awake() => GeneratePointsAroundPatrolPoint();

	private void GeneratePointsAroundPatrolPoint()
	{
		Path = new Transform[amountOfPoints];
		
		for (int i = 1; i <= amountOfPoints; ++i)
		{
			GameObject pathPoint = new GameObject("Path Point #" + i);
			
			pathPoint.transform.SetParent(patrolPoint);

			pathPoint.transform.localPosition = PathPointPosition(i);
			Path[i - 1] = pathPoint.transform;
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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		if(patrolPoint != null)
		{
			Gizmos.DrawWireSphere(patrolPoint.position, radius);
		}
	}
}