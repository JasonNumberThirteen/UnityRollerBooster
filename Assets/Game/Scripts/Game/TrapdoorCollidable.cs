using UnityEngine;

public class TrapdoorCollidable : MonoBehaviour, ICollisionEnter
{
	public float minimumHingeJointAngle;

	public void TriggerOnCollisionEnter(GameObject sender)
	{
		if(TryGetComponent(out HingeJoint hj))
		{
			JointLimits jointLimits = hj.limits;

			jointLimits.min = minimumHingeJointAngle;
			hj.limits = jointLimits;

			Destroy(this);
		}
	}
}