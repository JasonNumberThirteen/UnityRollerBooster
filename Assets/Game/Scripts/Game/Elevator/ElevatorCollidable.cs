using UnityEngine;

public class ElevatorCollidable : MonoBehaviour, IColliderEnter, ICollisionExit
{
	public void TriggerOnCollisionEnter(GameObject sender) => sender.transform.SetParent(gameObject.transform);
	public void TriggerOnCollisionExit(GameObject sender) => sender.transform.SetParent(null);
}