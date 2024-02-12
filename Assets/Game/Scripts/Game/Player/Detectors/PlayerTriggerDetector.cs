using UnityEngine;

public class PlayerTriggerDetector : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.TryGetComponent(out ITriggerEnter te))
		{
			te.TriggerOnTriggerEnter(gameObject);
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if(collider.gameObject.TryGetComponent(out ITriggerExit te))
		{
			te.TriggerOnTriggerExit(gameObject);
		}
	}
}