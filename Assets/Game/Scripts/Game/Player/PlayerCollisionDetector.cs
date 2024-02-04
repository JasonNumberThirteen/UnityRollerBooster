using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out ICollidable collidable))
		{
			collidable.TriggerOnCollision(gameObject);
		}

		if(gameObject.TryGetComponent(out PlayerMovement pm))
		{
			pm.CheckFallDistance();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out IReversibleCollision reversibleCollision))
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