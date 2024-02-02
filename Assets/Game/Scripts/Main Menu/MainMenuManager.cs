using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public GameObject mainMenuPanel, settingsPanel, informationPanel;
	public GameSceneManager sceneManager;
	public ScreenFader screenFader;
	public Button[] buttonsToDisable;

	public void OnExitClick() => Application.Quit();
	public void OnSettingsClick() => SetSettingsActive(true);
	public void OnBackFromSettingsClick() => SetSettingsActive(false);
	public void OnInformationClick() => SetInformationActive(true);
	public void OnBackFromInformationClick() => SetInformationActive(false);

	public void OnStartGameClick()
	{
		screenFader.isFadingOut = false;

		foreach (Button button in buttonsToDisable)
		{
			button.interactable = false;
		}

		Invoke(nameof(LoadGameScene), screenFader.duration);
	}

	private void LoadGameScene() => sceneManager.LoadScene();
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