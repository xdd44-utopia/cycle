using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneVideoTrigger : MonoBehaviour
{
	private HumanSubSceneSwitch scene;
	private VideoPlayer videoPlayer;
	private bool started = false;
	void Start()
	{
		scene = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.frame = 2;
		videoPlayer.Pause();
	}

	// Update is called once per frame
	void Update()
	{
		if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10 && !started) {
			videoPlayer.Play();
			started = true;
		}
		if ((int)videoPlayer.frame > (int)videoPlayer.frameCount - 10) {
			videoPlayer.Pause();
			scene.switchScene(1);
			Destroy(this);
		}
	}
}
