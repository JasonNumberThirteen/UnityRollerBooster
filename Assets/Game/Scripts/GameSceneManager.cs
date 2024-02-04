using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
}