using UnityEngine;

public class CheckpointTriggerable : MonoBehaviour, ITriggerEnter
{
	public Transform respawnPoint;
	
	public void TriggerOnTriggerEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out PlayerRespawner pr))
		{
			pr.respawnPoint = respawnPoint;
		}
	}
}