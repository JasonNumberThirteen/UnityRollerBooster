using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out ICollisionEnter ce))
		{
			ce.TriggerOnCollisionEnter(gameObject);
		}

		if(gameObject.TryGetComponent(out PlayerMovement pm))
		{
			pm.CheckFallDistance();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out ICollisionExit ce))
		{
			ce.TriggerOnCollisionExit(gameObject);
		}
	}
}