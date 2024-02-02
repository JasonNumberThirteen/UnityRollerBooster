using UnityEngine;

public class GoalCollidable : MonoBehaviour, ICollidable
{
	public void TriggerOnCollision(GameObject sender)
	{
		if(sender.TryGetComponent(out PlayerMovement pm))
		{
			pm.enabled = false;
		}
	}
}