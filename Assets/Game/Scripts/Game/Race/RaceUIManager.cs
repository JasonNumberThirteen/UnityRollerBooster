using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
	public GameObject pauseMenuPanel;

	public void ControlPauseMenuDisplay() => pauseMenuPanel.SetActive(RaceManager.instance.stateManager.IsPaused());

	private void Start() => ControlPauseMenuDisplay();
}