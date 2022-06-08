using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorTask : MonoBehaviour
{
	public Animator scene;
	public GameObject boxPrefab;
	public float upperBound;
	public float lowerBound;
	public float leftBound;
	public float rightBound;
	private float intv;
	private GameObject[,] boxes = new GameObject[4, 11];
	private bool[,] clickable = new bool[4, 11] {
		{false, false, true, false, false, true, true, true, true, false, true},
		{false, true, true, true, true, false, false, true, true, true, true},
		{true, true, false, true, false, true, false, true, false, false, false},
		{false, false, true, false, false, false, false, false, true, false, false}
	};
	private int[] selectLimit = new int[3]{2, 3, 4};
	private bool[,,] ans = new bool[3, 4, 11] {
		{
			{false, false, false, false, false, false, false, false, true, false, true},
			{false, false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false, false}
		},
		{
			{false, false, false, false, false, false, false, false, false, false, false},
			{false, true, false, false, false, false, false, false, false, false, false},
			{false, false, false, true, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, true, false, false}
		},
		{
			{false, false, false, false, false, false, false, true, false, false, false},
			{false, false, false, false, false, false, false, false, false, true, true},
			{true, false, false, false, false, false, false, false, false, false, false},
			{false, false, false, false, false, false, false, false, false, false, false}
		}
	};
	private int cur = 0;
	void Start()
	{
		intv = (rightBound - leftBound) / 10f;
		for (int i=0;i<4;i++) {
			for (int j=0;j<11;j++) {
				if (clickable[i, j]) {
					boxes[i, j] = Instantiate(boxPrefab, transform);
					boxes[i, j].transform.localPosition = new Vector3(Mathf.Lerp(leftBound, rightBound, j / 10f), Mathf.Lerp(upperBound, lowerBound, i / 3f), 0);
				}
			}
		}
		clearInput();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}
		Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
		Vector3 localPosition = currentWorldPosition - transform.position;
		int x = (int)Mathf.Floor((upperBound + intv / 2 - localPosition.y) / intv);
		int y = (int)Mathf.Floor((localPosition.x - (leftBound - intv / 2)) / intv);
		if (clickable[x, y]) {
			if (boxes[x, y].activeSelf) {
				boxes[x, y].SetActive(false);
			}
			else if (countInput() < selectLimit[cur]) {
				boxes[x, y].SetActive(true);
			}
			else {
				GameObject.Find("LogController").GetComponent<LogController>().addLog("Exceeds, current: " + cur + " " + selectLimit[cur]);
			}
		}
		else if (x >= 2 && y >= 9) {
			testResult();
		}
	}
	
	private void testResult() {
		for (int i=0;i<4;i++) {
			for (int j=0;j<11;j++) {
				if (clickable[i, j] && boxes[i, j].activeSelf != ans[cur, i, j]) {
					scene.SetTrigger("Incorrect");
					return;
				}
			}
		}
		scene.SetTrigger("Trigger");
		GameObject.Find("LogController").GetComponent<LogController>().addLog("Color task success");
		cur++;
		clearInput();
	}

	private void clearInput() {
		for (int i=0;i<4;i++) {
			for (int j=0;j<11;j++) {
				if (clickable[i, j]) {
					boxes[i, j].SetActive(false);
				}
			}
		}
	}

	private int countInput() {
		int ret = 0;
		for (int i=0;i<4;i++) {
			for (int j=0;j<11;j++) {
				if (clickable[i, j] && boxes[i, j].activeSelf) {
					ret++;
				}
			}
		}
		return ret;
	}

}
