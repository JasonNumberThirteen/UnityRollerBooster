using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
	public Transform respawnPoint;
	public float minimumY = -10f;
	[Min(0.01f)] public float freezeDuration = 1f;
	public GameObject fracturedBall;

	private Rigidbody rb;

	public void RespawnByFall()
	{
		Vector3 hitPosition = transform.position;
		
		Instantiate(fracturedBall, hitPosition, Quaternion.identity);
		Respawn();
	}

	public void Respawn()
	{
		transform.position = respawnPoint.position;
		rb.isKinematic = true;

		Invoke(nameof(DisableKinematicBody), freezeDuration);
	}

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void DisableKinematicBody() => rb.isKinematic = false;

	private void Update()
	{
		if(transform.position.y <= minimumY)
		{
			Respawn();
		}
	}
}