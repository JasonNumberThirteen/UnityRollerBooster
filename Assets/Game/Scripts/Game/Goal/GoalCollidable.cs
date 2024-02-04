using UnityEngine;

public class GoalCollidable : MonoBehaviour, IColliderEnter
{
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out PlayerMovement pm))
		{
			pm.enabled = false;
		}

		if(TryGetComponent(out GoalRenderer gr))
		{
			gr.ChangeMaterial();
		}
	}
}