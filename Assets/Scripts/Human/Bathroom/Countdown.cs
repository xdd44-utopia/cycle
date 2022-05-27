using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
	public int beforeSceneNum;
	public int nextSceneNum;
	public float totalTime;
	private HumanSubSceneSwitch controller;
	private int goal = 3;
	private int count = 0;
	private float timer;
	private Transform mask;
	private Vector3 maskCenterPos;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		mask = this.gameObject.transform.GetChild(1);
		maskCenterPos = mask.localPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) < 10) {
			timer += Time.deltaTime;
		}
		if (controller == null) {
			controller = Camera.main.gameObject.GetComponent<HumanSubSceneSwitch>();
		}
		if (count == goal) {
			controller.switchScene(nextSceneNum);
			Destroy(this);
		}
		if (totalTime < timer) {
			controller.switchScene(beforeSceneNum);
			Destroy(this);
		}
		else
		{
			mask.transform.localScale = new Vector3(1-timer / totalTime, 1, 1);
			mask.transform.localPosition = new Vector3(maskCenterPos.x - 5.5f * (timer / totalTime), maskCenterPos.y, maskCenterPos.z);
		}

	}
	public void addCount()
	{
		count++;
	}
}
