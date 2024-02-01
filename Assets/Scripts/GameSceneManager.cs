using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public string sceneName;

	public void LoadScene() => SceneManager.LoadScene(sceneName);
}