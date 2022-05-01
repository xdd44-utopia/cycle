using System;
using UnityEngine;
using UnityEngine.Video;

public class Startup : MonoBehaviour
{
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
		if (videoPlayer.frame == (long)(videoPlayer.frameCount - 1)) {
			animFinished();
		}
	}

	private void animFinished() {
		try {
			firstArc.GetComponent<ArcController>().switchStates();
		}
		catch (NullReferenceException e) {

		}
		try {
			firstArc.GetComponent<Arc5Controller>().switchStates();
		}
		catch (NullReferenceException e) {
			
		}
		Destroy(this.gameObject);
	}
}
