using UnityEngine;

public class HostileBallCollidable : MonoBehaviour, ICollisionEnter
{
	[Min(0f)] public float pushForce = 10f;
	
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out Rigidbody rb))
		{
			rb.AddRelativeForce(pushForce*PushDirection(sender), ForceMode.Impulse);
		}
	}

	private Vector3 PushDirection(GameObject sender)
	{
		Vector3 direction = transform.position - sender.transform.position;

		direction.y = 0;

		return direction.normalized;
	}
}