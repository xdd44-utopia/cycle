using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanSubSceneSwitch : MonoBehaviour
{
	public Transform[] scenes;
	public GameObject[] day2Prefab;
	public GameObject[] day3Prefab;
	public SpriteRenderer blind;
	private enum Status {
		Still,
		FadeIn,
		FadeOut
	};
	private Status status;
	private float timer;
	private float fadeTime = 1f;
	public int startScene;
	private int currentScene;
	private int targetScene;
	private int dayCount = 0;
	// Start is called before the first frame update
	void Start()
	{
		currentScene = 0;
		if (startScene > 0) {
			switchScene(startScene);
		}
	}

	// Update is called once per frame
	void Update()
	{
		switch (status) {
			case Status.FadeIn: {
				timer += Time.deltaTime;
				if (timer > fadeTime) {
					blind.color = new Color(0, 0, 0, 0);
					timer = 0;
					status = Status.Still;
				}
				else {
					blind.color = new Color(0, 0, 0, 1 - timer / fadeTime);
				}
				break;
			}
			case Status.FadeOut: {
				timer += Time.deltaTime;
				if (timer > fadeTime) {
					blind.color = new Color(0, 0, 0, 1);
					timer = 0;
					status = Status.FadeIn;
					// Debug.Log("Day: " + dayCount + " " + currentScene);
					GameObject replaced = null;
					Destroy(scenes[currentScene].gameObject);
					if (currentScene > 0) {
						replaced = Instantiate(dayCount == 1 ? day2Prefab[currentScene] : day3Prefab[currentScene], scenes[currentScene].position, scenes[currentScene].localRotation);
						scenes[currentScene] = replaced.transform;
					}
					currentScene = targetScene;
					transform.position = new Vector3(scenes[targetScene].position.x, scenes[targetScene].position.y, -10);
				}
				else {
					blind.color = new Color(0, 0, 0, timer / fadeTime);
				}
				break;
			}
		}
	}
	public void switchScene(int x) {
		timer = 0;
		targetScene = x;
		status = Status.FadeOut;
		if (currentScene == 5) {
			if (dayCount < 2) {
				dayCount++;
			}
			else {
				SceneManager.LoadScene(sceneName:"Bird");
			}
		}
	}
	public void switchSceneWithoutFade(int x) {
		targetScene = x;
		Destroy(scenes[currentScene].gameObject);
		if (currentScene > 0) {
			GameObject replaced = Instantiate(dayCount == 1 ? day2Prefab[currentScene] : day3Prefab[currentScene], scenes[currentScene].position, scenes[currentScene].localRotation);
			scenes[currentScene] = replaced.transform;
		}
		currentScene = targetScene;
		transform.position = new Vector3(scenes[targetScene].position.x, scenes[targetScene].position.y, -10);
	}
}
