using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SocializeTask : MonoBehaviour
{
	public PeopleController[] people;
	private AudioManager audioManager;
	private Animator anim;
	private bool isStarted = false;
	private bool isFinished = false;
	void Start()
	{
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		if (!isStarted && Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10) {
			isStarted = true;
			audioManager.playClip(20);
		}
		isFinished = true;
		for(int i = 0; i < 4; i++) {
			if (!people[i].isFruit) {
				isFinished = false;
				break;
			}
		}
		if (isFinished) {
			anim.SetTrigger("Trigger");
		}
	}

	public void endScene() {
		SceneManager.LoadScene(sceneName:"Bird");
	}
}
