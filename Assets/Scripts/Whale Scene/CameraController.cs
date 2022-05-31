using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
	public bool isUseMoveOnScreenEdge = true;
	public VideoPlayer videoPlayer;
	public MeshRenderer videoRenderer;
	private float moveSpeed = 3f;
	private bool MoveUp;
	private bool MoveDown;
	private bool MoveRight;
	private bool MoveLeft;
	private Rect RigthRect;
	private Rect UpRect;
	private Rect DownRect;
	private Rect LeftRect;
	private Vector3 dir = Vector3.zero;
	private Camera cam;
	private float maxWidth = 35f;
	private float maxHeight = 15f;
	private bool isSceneEnd = false;
	// Start is called before the first frame update
	void Start()
	{
		cam = GetComponent<Camera>();
		videoPlayer.frame = 2;
		videoPlayer.Pause();
		videoRenderer.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (isSceneEnd) {
			transform.position = new Vector3(100, 0, 0);
			cam.orthographicSize = 5.4f;
			if (!videoRenderer.enabled) {
				videoRenderer.enabled = true;
				videoPlayer.Play();
			}
		}
		else if (isUseMoveOnScreenEdge)
		{
			UpRect = new Rect(0, 3 * Screen.height / 4, Screen.width, Screen.height / 4);
			DownRect = new Rect(0, 0, Screen.width, Screen.height / 4);

			LeftRect = new Rect(0, 0, Screen.width / 4, Screen.height);
			RigthRect = new Rect(3 * Screen.width / 4, 0, Screen.width / 4, Screen.height);


			MoveUp = (UpRect.Contains(Input.mousePosition));
			MoveDown = (DownRect.Contains(Input.mousePosition));

			MoveLeft = (LeftRect.Contains(Input.mousePosition));
			MoveRight = (RigthRect.Contains(Input.mousePosition));

			dir.y = MoveUp ? 1 : MoveDown ? -1 : 0;
			dir.x = MoveLeft ? -1 : MoveRight ? 1 : 0;

			transform.position = Vector3.Lerp(transform.position, transform.position + dir * moveSpeed, Time.deltaTime);
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, - maxWidth + cam.orthographicSize * cam.aspect, maxWidth - cam.orthographicSize * cam.aspect),
				Mathf.Clamp(transform.position.y, - maxHeight + cam.orthographicSize, maxHeight - cam.orthographicSize), 
				-20
			);
		}
		if ((int)videoPlayer.frame > (int)videoPlayer.frameCount - 5) {
			videoPlayer.Pause();
			SceneManager.LoadScene(sceneName:"StartUp");
			Destroy(this);
		}
	}

	public void endScene() {
		isSceneEnd = true;
	}
}
