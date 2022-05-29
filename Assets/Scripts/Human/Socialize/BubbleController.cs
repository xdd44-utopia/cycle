using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleController : MonoBehaviour
{
	public SpriteRenderer[] Icons;
	public float MaxWaitTime;
	public float GoalTime;
	public SpriteRenderer bubble;
	private SpriteRenderer icon;
	private float acc = 1;
	private float accSpeed = 5;
	private float decaySpeed = 2;
	private Color redColor = new Color(255f / 255f, 71f / 255f, 85f / 255f, 1f);
	private Color greenColor = new Color(96f / 255f, 187f / 255f, 153f / 255f, 1f);
	private bool defeated = false;
	private bool isMouseDown = false;
	void Start()
	{
		int openIcon = Random.Range(0, 5);
		for(int i = 0; i < 5; i++) {
			if (i == openIcon) {
				Icons[i].enabled = true;
				icon = Icons[i];
			}
			else {
				Destroy(Icons[i].gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (isMouseDown) {
			acc += Time.deltaTime * accSpeed;
		}
		if (acc > GoalTime) {
			GetComponent<Animator>().SetTrigger("Trigger");
		}
		else if (acc < - MaxWaitTime && !defeated) {
			defeated = true;
			transform.parent.gameObject.GetComponent<PeopleController>().change();
			GetComponent<Animator>().SetTrigger("Trigger");
		}
		else if (acc > 0) {
			bubble.color = new Color(
				Mathf.Lerp(redColor.r, greenColor.r, acc / GoalTime),
				Mathf.Lerp(redColor.g, greenColor.g, acc / GoalTime),
				Mathf.Lerp(redColor.b, greenColor.b, acc / GoalTime),
				1
			);
			icon.color = new Color(1, 1, 1, 1);
		}
		else {
			bubble.color = new Color(
				redColor.r,
				redColor.g,
				redColor.b,
				1 + acc / MaxWaitTime
			);
			icon.color = new Color(1, 1, 1, 1 + acc / MaxWaitTime);
		}
		acc -= Time.deltaTime * decaySpeed;
	}
	private void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject() || defeated) {
			return;
		}
		isMouseDown = true;
	}
	private void OnMouseUp() {
		if (EventSystem.current.IsPointerOverGameObject() || defeated) {
			return;
		}
		isMouseDown = false;
	}
	private void OnMouseExit() {
		if (EventSystem.current.IsPointerOverGameObject() || defeated) {
			return;
		}
		isMouseDown = false;
	}
	public void destroyThis() {
		Destroy(this.gameObject);
	}
}
