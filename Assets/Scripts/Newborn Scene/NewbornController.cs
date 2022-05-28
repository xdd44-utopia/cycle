using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NewbornController : MonoBehaviour
{
	public CircleController circle;
	public AudioManager audioManager;
	public Animator circleAnime;
	private VideoPlayer videoPlayer;
	private int[] st = new int[5]{4, 600, 875, 1225, 1500};
	private int[] ed = new int[5]{50, 640, 900, 1265, 1545};
	private int cur = -1;
	private bool manual = false;
	private bool isSwitched = false;
	// Start is called before the first frame update
	void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.frame = 2;
		videoPlayer.Pause();
	}

	// Update is called once per frame
	void Update()
	{
		if (manual) {
			if (circle.accAngle / 2 >= ed[cur]) {
				manual = false;
				videoPlayer.Play();
			}
			else {
				if (circle.accAngle / 2 < st[cur]) {
					circle.accAngle = st[cur] * 2;
				}
				videoPlayer.frame = (long)circle.accAngle / 2;
			}
		}
		else {
			circle.accAngle = videoPlayer.frame * 2;
			if (cur < 4 && videoPlayer.frame == st[cur + 1]) {
				cur++;
				manual = true;
				videoPlayer.Pause();
			}
		}
		if (videoPlayer.frame > 1200 && videoPlayer.frame <= 1880 && !isSwitched) {
			isSwitched = true;
			audioManager.playClip(3);
		}
		if (videoPlayer.frame > 1880) {
			isSwitched = false;
			circleAnime.SetBool("Trigger2", true);
		}
		if (videoPlayer.frame > 4050 && !isSwitched) {
			isSwitched = true;
			audioManager.playClip(-1);
		}
		if ((int)videoPlayer.frame > (int)videoPlayer.frameCount - 10) {
			videoPlayer.Pause();
			SceneManager.LoadScene(sceneName:"Whale");
		}
	}

	public void activate() {
		videoPlayer.Play();
		circleAnime.SetBool("Trigger", true);
		Debug.Log("Activated!");
	}
}
