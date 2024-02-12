using UnityEngine;

public class Trapdoor : MonoBehaviour
{
	public float minimumHingeJointAngle;

	public void Unlock(GameObject sender)
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