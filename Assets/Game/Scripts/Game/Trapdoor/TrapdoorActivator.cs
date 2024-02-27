using UnityEngine;

public class TrapdoorActivator : MonoBehaviour
{
	public float minimumHingeJointAngle;

	public void Activate(GameObject sender)
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