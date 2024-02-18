using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public GameObject mainMenuPanel, settingsPanel, informationPanel, exitConfirmationPanel;
	public GameSceneManager sceneManager;
	public ScreenFader screenFader;
	public Button[] buttonsToDisable;

	private string sceneName;

	public void OnSettingsClick() => SetSettingsActive(true);
	public void OnBackFromSettingsClick() => SetSettingsActive(false);
	public void OnInformationClick() => SetInformationActive(true);
	public void OnBackFromInformationClick() => SetInformationActive(false);
	public void OnExitClick() => SetExitConfirmationActive(true);
	public void OnExitConfirmationYesClick() => Application.Quit();
	public void OnExitConfirmationNoClick() => SetExitConfirmationActive(false);

	public void OnStartGameClick(string sceneName)
	{
		screenFader.isFadingOut = false;
		this.sceneName = sceneName;

		foreach (Button button in buttonsToDisable)
		{
			button.interactable = false;
		}

		Invoke(nameof(LoadGameScene), screenFader.duration);
	}

	private void LoadGameScene() => sceneManager.LoadScene(sceneName);

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

	private void SetExitConfirmationActive(bool active)
	{
		mainMenuPanel.SetActive(!active);
		exitConfirmationPanel.SetActive(active);
	}
}