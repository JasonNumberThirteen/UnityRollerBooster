using UnityEngine;

public class TrapdoorTriggerable : MonoBehaviour, ITriggerEnter
{
	public Trapdoor[] trapdoors;
	
	public void TriggerOnTriggerEnter(GameObject sender)
	{
		foreach (Trapdoor trapdoor in trapdoors)
		{
			trapdoor.Unlock(sender);
		}
	}
}