using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSubSceneSwitch : MonoBehaviour
{
	public Vector3[] pos;
	public Animator birdA;
	public Animator birdB;
	private enum Status {
		Still,
		Acc,
		Deacc,
		Const
	};
	private Status status;
	private Vector3 targetPos;
	private Vector3 speed;
	private float maxSpeed = 5f;
	private float deaccDist = 5;
	// Start is called before the first frame update
	void Start()
	{
		switchScene(0);
	}

	// Update is called once per frame
	void Update()
	{
		if ((transform.position - targetPos).magnitude > 0.01f) {
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
		}
	}
	public void switchScene(int x) {
		if (x >= pos.Length) {
			return;
		}
		targetPos = pos[x];
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
				break;
			}
		}
	}
}
