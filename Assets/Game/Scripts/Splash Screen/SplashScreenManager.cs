using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
	public GameSceneManager sceneManager;
	[Min(0.01f)] public float sceneLoadDelay = 5f;
	public string sceneName;
	
	private void Start() => Invoke(nameof(LoadScene), sceneLoadDelay);
	private void LoadScene() => sceneManager.LoadScene(sceneName);
}