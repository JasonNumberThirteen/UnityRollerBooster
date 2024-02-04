using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public RaceUIManager uiManager;
	public RaceStateManager stateManager;
	public GameObject pauseMenuPanel;
	public GameSceneManager sceneManager;

	public void SwitchPause()
	{
		if(stateManager.IsWon() || stateManager.IsOver())
		{
			return;
		}

		stateManager.SwitchPauseState();
		
		Time.timeScale = stateManager.IsPaused() ? 0 : 1;

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