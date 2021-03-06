using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BathroomTaskController : MonoBehaviour
{
	public int MinAngle;
	public int MaxAngle;
	public float threshold;
	public float goal;
	public ProgressBar progressBar;
	public Countdown countdown;
	public SpriteRenderer sprite;
	public int audioID;
	public float audioLength;
	private float audioTimer = 0;
	private float acc;
	private Vector3 preMousepos;
	private bool isMoving;
	private float timer = 0;
	private bool isFinished;
	// Start is called before the first frame update
	void Start()
	{
		isFinished = false;
		isMoving = false;
		audioTimer = audioLength + 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (isMoving) {
			acc += Time.deltaTime;
			timer += Time.deltaTime;
			if (timer > 0.1f) {
				isMoving = false;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().pauseClip(audioID);
				audioTimer = audioLength + 1;
			}
		}
		if (acc > goal) {
            if (!isFinished)
            {
				countdown.addCount();
				isFinished = true;
				Destroy(this);
			}
		}
		else {
			progressBar.updateBar(acc / goal);
			if (sprite != null) {
				sprite.color = new Color(1, 1, 1, 1 - acc / goal);
			}
		}
		audioTimer += Time.deltaTime;
	}
	private void OnMouseDrag() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		Vector3 deltapos = Vector3.zero;
		if ((Input.mousePosition - preMousepos).magnitude > 1) {
			deltapos = Input.mousePosition - preMousepos;
		}
		preMousepos = Input.mousePosition;
		if (deltapos.magnitude > 0) {
			float angle = Mathf.Atan(Mathf.Abs(deltapos.y) / Mathf.Abs(deltapos.x));
			angle = angle * 180 / Mathf.PI;
			if (deltapos.magnitude > threshold && angle > MinAngle && angle < MaxAngle) {
				if (audioTimer > audioLength) {
					audioTimer = 0;
					GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip(audioID);
				}
				isMoving = true;
				timer = 0;
			}
		}
	}
}
