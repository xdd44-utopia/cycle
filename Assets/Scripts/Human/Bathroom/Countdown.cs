using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
	public int beforeSceneNum;
	public int nextSceneNum;
	public float totalTime;
	public Transform mask;
	private float empty;
	private HumanSubSceneSwitch controller;
	private int goal = 3;
	private int count = 0;
	private float timer;
	private Vector3 maskCenterPos;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		empty = mask.localPosition.x;
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
			Debug.Log("?");
			controller.switchScene(beforeSceneNum);
			Destroy(this);
		}
		else {
			mask.localPosition = new Vector3(Mathf.Lerp(empty, 0, 1 - timer / totalTime), 0, 0);
		}

	}
	public void addCount()
	{
		count++;
	}
}
