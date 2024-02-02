using UnityEngine;

public class GoalRenderer : MonoBehaviour
{
	public Material activatedState;

	private Renderer r;

	public void ChangeMaterial()
	{
		Material[] materials = r.materials;

		materials[0] = activatedState;
		r.materials = materials;
	}

	private void Awake() => r = GetComponent<Renderer>();
}