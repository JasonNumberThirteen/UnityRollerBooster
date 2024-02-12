using UnityEngine;

public class FloatingFanTriggerable : MonoBehaviour, ITriggerEnter, ITriggerExit
{
	public Vector3 pushForce;
	[Min(0f)] public float drag;

	public void TriggerOnTriggerEnter(GameObject sender)
	{
		if(sender.TryGetComponent(out ConstantForce cf))
		{
			SetForce(cf, pushForce);
		}

		if(sender.TryGetComponent(out Rigidbody rb))
		{
			SetDrag(rb, drag);
		}
	}

	public void TriggerOnTriggerExit(GameObject sender)
	{
		if(sender.TryGetComponent(out ConstantForce cf))
		{
			SetForce(cf, Vector3.zero);
		}

		if(sender.TryGetComponent(out Rigidbody rb))
		{
			SetDrag(rb, 0);
		}
	}

	private void SetForce(ConstantForce cf, Vector3 force) => cf.force = force;
	private void SetDrag(Rigidbody rb, float drag) => rb.drag = drag;
}