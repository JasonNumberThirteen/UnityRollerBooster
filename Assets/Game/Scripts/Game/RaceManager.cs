using UnityEngine;

public class RaceManager : MonoBehaviour
{
	public static RaceManager instance;

	public GameObject pauseMenuPanel;

	public void PauseGame()
	{
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;
		
		pauseMenuPanel.SetActive(Time.timeScale == 0);
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