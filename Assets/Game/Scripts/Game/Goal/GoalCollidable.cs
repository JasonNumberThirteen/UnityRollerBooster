using UnityEngine;

public class GoalCollidable : MonoBehaviour, ICollisionEnter
{
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		RaceManager.instance.SetRaceAsWon();
		
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