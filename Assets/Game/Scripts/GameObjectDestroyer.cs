using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
	[Min(0f)] public float delay;
	
	private void Start() => Destroy(gameObject, delay);
}