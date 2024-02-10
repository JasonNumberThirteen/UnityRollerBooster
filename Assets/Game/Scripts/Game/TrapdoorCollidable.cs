using UnityEngine;

public class TrapdoorCollidable : MonoBehaviour, ICollisionEnter
{
	public void TriggerOnCollisionEnter(GameObject sender)
	{
		if(TryGetComponent(out HingeJoint hj))
		{
			JointLimits jointLimits = hj.limits;

			jointLimits.min = -90;
			hj.limits = jointLimits;
		}
	}
}