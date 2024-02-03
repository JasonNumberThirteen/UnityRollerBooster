using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public GameObject pauseMenuPanel;

	public void PauseGame()
	{
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;

		SetPauseMenuPanelActive();
	}

	private void Awake() => CheckSingleton();
	private void Start() => SetPauseMenuPanelActive();
	private void SetPauseMenuPanelActive() => pauseMenuPanel.SetActive(Time.timeScale == 0);

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