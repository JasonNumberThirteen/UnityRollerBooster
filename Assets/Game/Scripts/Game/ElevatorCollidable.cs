using UnityEngine;

public class ElevatorCollidable : MonoBehaviour, ICollidable
{
	public void TriggerOnCollision(GameObject sender) => sender.transform.SetParent(gameObject.transform);
}