using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
	public Transform respawnPoint;
	public float minimumY = -10f;
	[Min(0.01f)] public float freezeDuration = 1f;

	private Rigidbody rb;

	private void Awake() => rb = GetComponent<Rigidbody>();

	private void Update()
	{
		if(transform.position.y <= minimumY)
		{
			OnRespawn();
		}
	}

	private void OnRespawn()
	{
		transform.position = respawnPoint.position;
		rb.isKinematic = true;

		Invoke(nameof(DisableKinematicBody), freezeDuration);
	}

	private void DisableKinematicBody() => rb.isKinematic = false;
}