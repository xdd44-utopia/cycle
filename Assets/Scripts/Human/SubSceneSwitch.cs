using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSceneSwitch : MonoBehaviour
{
	public Transform[] scenes;
	public SpriteRenderer blind;
	private enum Status {
		Still,
		FadeIn,
		FadeOut
	};
	private Status status;
	private float timer;
	private float fadeTime = 2.5f;
	private int targetScene;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		status = Status.FadeIn;
		targetScene = 0;
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
					transform.position = scenes[targetScene].position;
				}
				else {
					blind.color = new Color(0, 0, 0, timer / fadeTime);
				}
				break;
			}
		}
	}
	public void switchScene(int x) {
		targetScene = x;
		status = Status.FadeOut;
	}
}
