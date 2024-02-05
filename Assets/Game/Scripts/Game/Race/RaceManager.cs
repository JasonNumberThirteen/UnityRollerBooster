using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public RaceUIManager uiManager;
	public RaceStateManager stateManager;
	public GameObject pauseMenuPanel;
	public GameSceneManager sceneManager;
	public PlayerMovement playerMovement;
	public PlayerRespawner playerRespawner;

	public void SetRaceAsWon()
	{
		stateManager.SetAsWon();

		playerMovement.enabled = false;
		playerRespawner.enabled = false;
	}

	public void SwitchPause()
	{
		if(stateManager.IsWon() || stateManager.IsOver())
		{
			return;
		}

		stateManager.SwitchPauseState();
		SetTimeScale(stateManager.IsPaused() ? 0 : 1);
		uiManager.ControlPauseMenuDisplay();
	}

	public void AbortRace(string sceneName)
	{
		SetTimeScale(1);
		sceneManager.LoadScene(sceneName);
	}

	public void StartRace()
	{
		stateManager.SetAsActive();

		playerMovement.enabled = true;
	}

	private void Awake() => CheckSingleton();
	private void SetTimeScale(float scale) => Time.timeScale = scale;

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