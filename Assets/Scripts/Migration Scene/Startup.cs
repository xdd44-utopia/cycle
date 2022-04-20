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
		firstArc.GetComponent<ArcController>().switchStates();
		Destroy(this.gameObject);
	}
}
