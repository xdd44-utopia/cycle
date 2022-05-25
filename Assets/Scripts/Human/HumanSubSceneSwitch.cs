using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private bool isDay3 = false;
	// Start is called before the first frame update
	void Start()
	{
		currentScene = 0;
		switchScene(startScene);
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
					GameObject replaced = Instantiate(isDay3 ? day3Prefab[currentScene] : day2Prefab[currentScene], scenes[currentScene].position, scenes[currentScene].localRotation);
					isDay3 = true;
					Destroy(scenes[currentScene].gameObject);
					scenes[currentScene] = replaced.transform;
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
		switch(x) {
			case 5: {
				scenes[5].gameObject.GetComponent<Animator>().SetTrigger("Trigger");
				break;
			}
		}
	}
}
