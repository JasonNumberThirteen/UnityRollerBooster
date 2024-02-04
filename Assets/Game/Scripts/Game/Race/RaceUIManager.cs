using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
	public GameObject pauseMenuPanel;

	public void SetPauseMenuPanelActive() => pauseMenuPanel.SetActive(Time.timeScale == 0);

	private void Start() => SetPauseMenuPanelActive();
}