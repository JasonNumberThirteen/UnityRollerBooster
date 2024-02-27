using UnityEngine;

public class TrapdoorTriggerable : MonoBehaviour, ITriggerEnter
{
	public TrapdoorActivator[] activators;
	
	public void TriggerOnTriggerEnter(GameObject sender)
	{
		foreach (TrapdoorActivator activator in activators)
		{
			activator.Unlock(sender);
		}
	}
}