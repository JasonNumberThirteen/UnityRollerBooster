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
		Instantiate(fracturedBall, transform.position, Quaternion.identity);
		Respawn();
	}

	public void Respawn()
	{
		GoToRespawnPoint();
		SetKinematicBody(true);
		Invoke(nameof(DisableKinematicBody), freezeDuration);
	}

	private void Awake() => rb = GetComponent<Rigidbody>();
	private void DisableKinematicBody() => SetKinematicBody(false);
	private void SetKinematicBody(bool isKinematic) => rb.isKinematic = isKinematic;
	private void GoToRespawnPoint() => transform.position = respawnPoint.position;
	private bool FallenOutsideOfArea() => transform.position.y <= minimumY;

	private void Update()
	{
		if(FallenOutsideOfArea())
		{
			Respawn();
		}
	}
}