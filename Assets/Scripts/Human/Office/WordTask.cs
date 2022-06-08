using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordTask : MonoBehaviour
{
	public Animator scene;
	public Animator selectorAnim;
	public Transform selectorTransform;
	public GameObject boxPrefab;
	public Sprite[] boxSprites;
	public float upperBound;
	public float lowerBound;
	public float leftBound;
	public float rightBound;
	private Collider2D formCollider;
	private GameObject[,] boxes = new GameObject[4, 5];
	private float intVertical;
	private float intHorizontal;
	private int curX = 0;
	private int curY = 0;
	// private int[,] cur = new int[4, 5] {
	// 	{1, 2, 3, 3, 4},
	// 	{2, 1, 4, 3, 2},
	// 	{3, 3, 3, 3, 4},
	// 	{0, 0, 0, 0, 0}
	// };
	private int[,] cur = new int[4, 5] {
		{1, 2, 3, 3, 4},
		{0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0}
	};
	private int[,] ans = new int[4, 5] {
		{1, 2, 3, 3, 4},
		{2, 1, 4, 2, 1},
		{3, 3, 3, 3, 4},
		{1, 2, 1, 2, 2}
	};
	public bool isEnabled;
	void Start()
	{
		formCollider = GetComponent<Collider2D>();
		intHorizontal = (rightBound - leftBound) / 4f;
		intVertical = (upperBound - lowerBound) / 3f;
		for (int i=0;i<4;i++) {
			for (int j=0;j<5;j++) {
				boxes[i, j] = Instantiate(boxPrefab, transform);
				boxes[i, j].transform.localPosition = new Vector3(Mathf.Lerp(leftBound, rightBound, j / 4f), Mathf.Lerp(upperBound, lowerBound, i / 3f), 0);
				boxes[i, j].GetComponent<SpriteRenderer>().sprite = boxSprites[cur[i, j]];
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject() || selectorTransform.localScale.magnitude > 0 || !isEnabled) {
			return;
		}
		Vector3 currentScenePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint(currentScenePosition) - new Vector3(0, 0, Camera.main.transform.position.z);
		Vector3 localPosition = currentWorldPosition - transform.position;
		int x = (int)Mathf.Floor((upperBound + intVertical / 2 - localPosition.y) / intVertical);
		int y = (int)Mathf.Floor((localPosition.x - (leftBound - intHorizontal / 2)) / intHorizontal);
		if (x == 0 || x > 3 || y > 4) {
			return;
		}
		selectorAnim.SetTrigger("Open");
		formCollider.enabled = false;
		curX = x;
		curY = y;
		selectorTransform.localPosition = new Vector3(localPosition.x, localPosition.y, -0.01f);
	}

	public void select(int c) {
		selectorAnim.SetTrigger("Close");
		formCollider.enabled = false;
		formCollider.enabled = true;
		boxes[curX, curY].GetComponent<SpriteRenderer>().sprite = boxSprites[c];
		cur[curX, curY] = c;
		testResult();
	}

	private void testResult() {
		for (int i=0;i<4;i++) {
			for (int j=0;j<5;j++) {
				if (cur[i, j] != ans[i, j]) {
					Debug.Log(i + " " + j + " " + cur[i, j] + " " + ans[i, j]);
					return;
				}
			}
		}
		scene.SetTrigger("Trigger");
		GameObject.Find("LogController").GetComponent<LogController>().addLog("Word task success");
		Destroy(this);
	}
}
