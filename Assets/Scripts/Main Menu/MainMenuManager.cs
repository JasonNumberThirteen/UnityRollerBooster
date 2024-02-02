using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	public GameObject mainMenuPanel, settingsPanel, informationPanel;
	public GameSceneManager sceneManager;

	public void OnStartGameClick() => sceneManager.LoadScene();
	public void OnExitClick() => Application.Quit();
	public void OnSettingsClick() => SetSettingsActive(true);
	public void OnBackFromSettingsClick() => SetSettingsActive(false);
	public void OnInformationClick() => SetInformationActive(true);
	public void OnBackFromInformationClick() => SetInformationActive(false);

	private void SetSettingsActive(bool active)
	{
		mainMenuPanel.SetActive(!active);
		settingsPanel.SetActive(active);
	}

	private void SetInformationActive(bool active)
	{
		mainMenuPanel.SetActive(!active);
		informationPanel.SetActive(active);
	}
}