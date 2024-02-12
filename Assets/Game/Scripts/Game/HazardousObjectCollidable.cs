using UnityEngine;

public class HazardousObjectCollidable : MonoBehaviour, ICollisionEnter
{
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out PlayerRespawner pr))
		{
			pr.RespawnByFall();
		}
	}
}