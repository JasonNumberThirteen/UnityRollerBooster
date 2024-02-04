using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out IColliderEnter collidable))
		{
			collidable.TriggerOnCollisionEnter(gameObject);
		}

		if(gameObject.TryGetComponent(out PlayerMovement pm))
		{
			pm.CheckFallDistance();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out ICollisionExit reversibleCollision))
		{
			reversibleCollision.TriggerOnCollisionExit(gameObject);
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.TryGetComponent(out ITriggerable triggerable))
		{
			triggerable.TriggerOnTrigger(gameObject);
		}
	}
}