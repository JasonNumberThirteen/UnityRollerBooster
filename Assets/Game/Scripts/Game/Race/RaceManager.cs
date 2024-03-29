using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public RaceUIManager uiManager;
	public RaceStateManager stateManager;
	public GameObject pauseMenuPanel;
	public GameSceneManager sceneManager;
	public PlayerMover playerMover;
	public PlayerRespawner playerRespawner;
	public GoalCollidable goalCollidable;
	public GoalRenderer goalRenderer;

	public void SetRaceAsWon()
	{
		stateManager.SetAsWon();
		OnRaceEnd();
	}

	public void SetRaceAsOver()
	{
		stateManager.SetAsOver();
		OnRaceEnd();
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

		playerMover.enabled = true;
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

	private void OnRaceEnd()
	{
		Destroy(goalCollidable);
		Destroy(goalRenderer);

		playerMover.enabled = false;
		playerRespawner.enabled = false;
	}
}