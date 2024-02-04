using UnityEngine;

public class CheckpointTriggerable : MonoBehaviour, ITriggerable
{
	public Transform respawnPoint;
	
	public void TriggerOnTrigger(GameObject sender)
	{
		if(sender.TryGetComponent(out PlayerRespawner pr))
		{
			pr.respawnPoint = respawnPoint;
		}
	}
}