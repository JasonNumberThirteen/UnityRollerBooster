using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.TryGetComponent(out ICollidable collidable))
		{
			collidable.TriggerOnCollision(gameObject);
		}
	}
}