using UnityEngine;

public class PlayerTriggerDetector : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.TryGetComponent(out ITriggerable triggerable))
		{
			triggerable.TriggerOnTrigger(gameObject);
		}
	}
}