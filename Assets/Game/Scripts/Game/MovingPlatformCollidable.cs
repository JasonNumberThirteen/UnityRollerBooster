using UnityEngine;

public class MovingPlatformCollidable : MonoBehaviour, ICollisionEnter, ICollisionExit
{
	public void TriggerOnCollisionEnter(GameObject sender) => sender.transform.SetParent(gameObject.transform);
	public void TriggerOnCollisionExit(GameObject sender) => sender.transform.SetParent(null);
}