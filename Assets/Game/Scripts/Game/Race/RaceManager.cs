using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public RaceUIManager uiManager;
	public GameObject pauseMenuPanel;
	public GameSceneManager sceneManager;

	public void SwitchPause()
	{
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;

		uiManager.SetPauseMenuPanelActive();
	}

	public void AbortRace(string sceneName)
	{
		Time.timeScale = 1;
		
		sceneManager.LoadScene(sceneName);
	}

	private void Awake() => CheckSingleton();

	private void CheckSingleton()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}
}