using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
	public Transform respawnPoint;
	public float minimumY = -10f;

	private void Update()
	{
		if(transform.position.y <= minimumY)
		{
			transform.position = respawnPoint.position;
		}
	}
}