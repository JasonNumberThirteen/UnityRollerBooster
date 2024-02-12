using UnityEngine;

public class FloatingFanTriggerable : MonoBehaviour, ITriggerEnter, ITriggerExit
{
	public Vector3 pushForce;

	public void TriggerOnTriggerEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out ConstantForce cf))
		{
			SetForce(cf, pushForce);
		}
	}

	public void TriggerOnTriggerExit(GameObject sender)
	{
		if(sender.TryGetComponent(out ConstantForce cf))
		{
			SetForce(cf, Vector3.zero);
		}
	}

	private void SetForce(ConstantForce cf, Vector3 force) => cf.force = force;
}