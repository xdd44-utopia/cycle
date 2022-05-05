using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbornCameraController : MonoBehaviour
{
	public AudioManager audioManager;
	public Camera mainCam;
	public Camera sceneCam;
	public RenderTexture targetTexture;
	public Animator elephant;
	public Animator video;
	private float speed = 0.5f;
	public float recurPos;
	public float endPos;
	private bool started = false;
	private bool switched = false;
	private float timer = 0;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (started) {
			transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
			if (transform.position.x > recurPos) {
				transform.position -= new Vector3(recurPos, 0, 0);
			}
			if (transform.position.x > endPos) {
				endScene();
			}
			timer += Time.deltaTime;
			if (timer > 10.5f) {
				switchCam();
			}
		}
	}

	public void startScene() {
		audioManager.playClip(2);
		started = true;
		transform.position = new Vector3(0, 125, -10);
	}

	private void switchCam() {
		if (!switched) {
			mainCam.enabled = false;
			sceneCam.enabled = true;
			switched = true;
		}
	}

	public void endScene() {
		mainCam.enabled = true;
		sceneCam.enabled = false;
		elephant.SetBool("Trigger", true);
		video.SetBool("Trigger", true);
	}
}
