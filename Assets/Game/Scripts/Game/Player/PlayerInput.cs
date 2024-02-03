using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
	public Vector2 MovementVector {get; private set;}
	
	private void OnMove(InputValue iv) => MovementVector = iv.Get<Vector2>();
}