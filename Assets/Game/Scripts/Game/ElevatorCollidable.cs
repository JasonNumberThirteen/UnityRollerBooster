using UnityEngine;

public class ElevatorCollidable : MonoBehaviour, ICollidable, IReversibleCollision
{
	public void TriggerOnCollision(GameObject sender) => sender.transform.SetParent(gameObject.transform);
	public void TriggerOnCollisionExit(GameObject sender) => sender.transform.SetParent(null);
}