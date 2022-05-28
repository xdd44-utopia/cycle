using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSubSceneSwitch : MonoBehaviour
{
	public AudioManager bgmManager;
	public Vector3[] pos;
	public Animator birdA;
	public Animator birdB;
	public Animator[] nests;
	public FoodCollector foodCollector;
	private bool nestTriggered = false;
	public int startScene;
	private enum Status {
		Still,
		Acc,
		Deacc,
		Const
	};
	private Status status;
	private int target;
	private int current;
	private Vector3 targetPos;
	private Vector3 speed;
	private float maxSpeed = 5f;
	private float deaccDist = 5;
	// Start is called before the first frame update
	void Start()
	{
		switchScene(startScene);
	}

	// Update is called once per frame
	void Update()
	{
		if ((transform.position - targetPos).magnitude > 0.25f) {
			switch (status) {
				case Status.Still: {
					speed = Vector3.zero;
					status = Status.Acc;
					break;
				}
				case Status.Const: {
					transform.position += speed * Time.deltaTime;
					if ((transform.position - targetPos).magnitude < deaccDist) {
						status = Status.Deacc;
					}
					break;
				}
				case Status.Acc: {
					transform.position += speed * Time.deltaTime;
					speed = (targetPos - transform.position).normalized * Mathf.Lerp(speed.magnitude, maxSpeed, 0.1f);
					if ((transform.position - targetPos).magnitude < deaccDist) {
						status = Status.Deacc;
					}
					if (maxSpeed - speed.magnitude < 0.01f || speed.magnitude > maxSpeed) {
						status = Status.Const;
						speed = speed.normalized * maxSpeed;
					}
					break;
				}
				case Status.Deacc: {
					speed = Vector3.zero;
					transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * maxSpeed / deaccDist);
					break;
				}
			}
		}
		else {
			status = Status.Still;
			current = target;
			switch (target) {
				case 2: {
					if (!nestTriggered) {
						bgmManager.playClip(0);
						nestTriggered = true;
						Debug.Log("trigger");
						nests[0].SetTrigger("Trigger");
					}
					break;
				}
				case 3: {
					if (!nestTriggered) {
						bgmManager.playClip(0);
						nestTriggered = true;
						foodCollector.isCollecting = false;
						maxSpeed = 5f;
						nests[1].SetTrigger("Trigger");
					}
					break;
				}
				case 4: {
					if (!nestTriggered) {
						bgmManager.playClip(0);
						nestTriggered = true;
						foodCollector.isCollecting = false;
						maxSpeed = 5f;
						nests[2].SetTrigger("Trigger");
					}
					break;
				}
				case 5: {
					if (!nestTriggered) {
						bgmManager.playClip(0);
						nestTriggered = true;
						foodCollector.isCollecting = false;
						maxSpeed = 5f;
						nests[3].SetTrigger("Trigger");
					}
					break;
				}
				case 6: {
					SceneManager.LoadScene(sceneName:"Elephant1");
					break;
				}
			}
		}
	}
	public void switchScene(int x) {
		if (x >= pos.Length) {
			return;
		}
		target = x;
		if (x < pos.Length) {
			targetPos = pos[x];
		}
		status = Status.Acc;
		switch (x) {
			case 0: {
				birdA.SetTrigger("Trigger");
				break;
			}
			case 1: {
				birdA.SetTrigger("Trigger");
				birdB.SetTrigger("Trigger");
				break;
			}
			case 2: {
				birdA.SetTrigger("Trigger");
				birdB.SetTrigger("Trigger");
				nestTriggered = false;
				break;
			}
			case 3: {
				bgmManager.playClip(1);
				birdA.SetTrigger("Trigger");
				maxSpeed = 2.5f;
				foodCollector.isCollecting = true;
				nestTriggered = false;
				break;
			}
			case 4: {
				bgmManager.playClip(1);
				birdA.SetTrigger("Trigger");
				maxSpeed = 2.5f;
				foodCollector.isCollecting = true;
				nestTriggered = false;
				nests[1].SetTrigger("Trigger");
				break;
			}
			case 5: {
				bgmManager.playClip(1);
				birdA.SetTrigger("Trigger");
				maxSpeed = 2.5f;
				foodCollector.isCollecting = true;
				nestTriggered = false;
				nests[2].SetTrigger("Trigger");
				break;
			}
			case 6: {
				maxSpeed = 5f;
				nests[3].SetTrigger("Trigger");
				break;
			}
		}
	}
	public void nextScene() {
		switchScene(current + 1);
	}
}
