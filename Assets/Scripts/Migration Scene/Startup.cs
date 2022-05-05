using System;
using UnityEngine;
using UnityEngine.Video;

public class Startup : MonoBehaviour
{
	public AudioManager audioManager;
	private VideoPlayer videoPlayer;
	public GameObject firstArc;
	// Start is called before the first frame update
	void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();
	}

	// Update is called once per frame
	void Update()
	{
		if (videoPlayer.frame > (long)(videoPlayer.frameCount - 5)) {
			animFinished();
		}
	}

	private void animFinished() {
		firstArc.GetComponent<ArcController>().switchStates();
		audioManager.playClip(1);
		Destroy(this.gameObject);
	}
}
