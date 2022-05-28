using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public Sprite fullscreenSprite;
	public Sprite windowSprite;
	public Image fullscreenIcon;
	public Slider volume;
	public Text volumeText;
	public SelectScreen selectScreen;
	private bool isFullscreen = true;
	// Start is called before the first frame update
	void Start()
	{
		if (!Settings.initiated) {
			Settings.volume = 1;
			Settings.initiated = true;
		}
		volumeChange();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void startGame() {
		Settings.startFromScratch = true;
		SceneManager.LoadScene(sceneName:"Human");
	}

	public void backToMain() {
		SceneManager.LoadScene(sceneName:"StartUp");
	}

	public void switchFullscreen() {
		if (isFullscreen) {
			Screen.fullScreenMode = FullScreenMode.Windowed;
			isFullscreen = false;
			fullscreenIcon.sprite = windowSprite;
		}
		else {
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
			isFullscreen = true;
			fullscreenIcon.sprite = fullscreenSprite;
		}
	}

	public void openSelectScreen() {
		selectScreen.switchTo(0);
	}

	public void volumeChange() {
		volumeText.text = (int)(100 * volume.value) + "%";
		Settings.volume = volume.value;
	}

	public void quitGame() {
		Application.Quit();
	}
}
