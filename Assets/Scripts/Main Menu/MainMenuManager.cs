using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	public GameObject mainMenuPanel, settingsPanel, informationPanel;
	public GameSceneManager sceneManager;

	public void OnStartGameClick() => sceneManager.LoadScene();
	public void OnExitClick() => Application.Quit();

	public void OnSettingsClick()
	{
		mainMenuPanel.SetActive(false);
		settingsPanel.SetActive(true);
	}

	public void OnInformationClick()
	{
		mainMenuPanel.SetActive(false);
		informationPanel.SetActive(true);
	}
}