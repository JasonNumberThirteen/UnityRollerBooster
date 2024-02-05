using UnityEngine;

public class GoalCollidable : MonoBehaviour, ICollisionEnter
{
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		RaceManager.instance.SetRaceAsWon();
		
		if(TryGetComponent(out GoalRenderer gr))
		{
			gr.ChangeMaterial();
		}
	}
}