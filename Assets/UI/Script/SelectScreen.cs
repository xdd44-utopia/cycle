using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectScreen : MonoBehaviour
{
	public RectTransform circle;
	public Text desc;
	public Button[] buttons;
	private string[] texts = new string[10]{
		"Human",
		"?",
		"Bird",
		"?",
		"Elephant",
		"?",
		"Whale",
		"?",
		"?",
		"?"
	};
	private int cur = 0;
	private enum Status {
		Still,
		FadeIn,
		FadeOut
	};
	private Status status;
	private float timer;
	private float fadeTime = 0.5f;
	void Start()
	{
		timer = 0;
		status = Status.FadeOut;
	}

	// Update is called once per frame
	void Update()
	{
		circle.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(circle.localRotation.eulerAngles.z, cur * 36, 0.025f));
		for (int i=0;i<buttons.Length;i++) {
			buttons[i].interactable = true;
		}
		buttons[cur].interactable = false;
		switch (status) {
			case Status.FadeIn: {
				timer += Time.deltaTime;
				if (timer > fadeTime) {
					desc.color = new Color(1, 1, 1, 1);
					timer = 0;
					status = Status.Still;
				}
				else {
					desc.color = new Color(1, 1, 1, timer / fadeTime);
				}
				break;
			}
			case Status.FadeOut: {
				timer += Time.deltaTime;
				if (timer > fadeTime) {
					desc.color = new Color(1, 1, 1, 0);
					timer = 0;
					status = Status.FadeIn;
					desc.text = texts[cur];
				}
				else {
					desc.color = new Color(1, 1, 1, 1 - timer / fadeTime);
				}
				break;
			}
		}
	}

	public void switchTo(int x) {
		cur = x;
		status = Status.FadeOut;
	}

	public void switchScene() {
		switch (cur) {
			case 0:
				SceneManager.LoadScene(sceneName:"Human");
				break;
			case 2:
				SceneManager.LoadScene(sceneName:"Bird");
				break;
			case 4:
				SceneManager.LoadScene(sceneName:"Elephant1");
				break;
			case 6:
				SceneManager.LoadScene(sceneName:"Whale");
				break;
		}
	}
	
}
