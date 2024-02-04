using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
	public GameObject pauseMenuPanel;

	public void SetPauseMenuPanelActive() => pauseMenuPanel.SetActive(RaceManager.instance.stateManager.IsPaused());

	private void Start() => SetPauseMenuPanelActive();
}